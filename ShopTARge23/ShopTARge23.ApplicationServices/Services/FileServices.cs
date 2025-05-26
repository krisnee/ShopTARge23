using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ShopTARge23.Core.Domain;
using ShopTARge23.Core.Dto;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Data;

namespace ShopTARge23.ApplicationServices.Services
{
    public class FileServices : IFileServices
    {
        private readonly IHostEnvironment _webHost;
        private readonly ShopTARge23Context _context;

        public FileServices(
            IHostEnvironment webHost,
            ShopTARge23Context context)
        {
            _webHost = webHost;
            _context = context;
        }

        // ===== SPACESHIP MEETODID =====
        public void FilesToApi(SpaceshipDto dto, Spaceship spaceship)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                string uploadsFolder = Path.Combine(_webHost.ContentRootPath, "multipleFileUpload");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                foreach (var file in dto.Files)
                {
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);

                        var path = new FileToApi
                        {
                            Id = Guid.NewGuid(),
                            ExistingFilePath = uniqueFileName,
                            SpaceshipId = spaceship.Id
                        };

                        _context.FileToApis.Add(path);
                    }
                }

                _context.SaveChanges();
            }
        }

        public async Task<FileToApi> RemoveImageFromApi(FileToApiDto dto)
        {
            var image = await _context.FileToApis
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (image != null)
            {
                string filePath = Path.Combine(_webHost.ContentRootPath, "multipleFileUpload", image.ExistingFilePath);

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                _context.FileToApis.Remove(image);
                await _context.SaveChangesAsync();
            }

            return null;
        }

        public async Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dtos)
        {
            foreach (var dto in dtos)
            {
                var image = await _context.FileToApis
                    .FirstOrDefaultAsync(x => x.ExistingFilePath == dto.ExistingFilePath);

                if (image != null)
                {
                    string filePath = Path.Combine(_webHost.ContentRootPath, "multipleFileUpload", image.ExistingFilePath);

                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                    _context.FileToApis.Remove(image);
                }
            }

            await _context.SaveChangesAsync();
            return null;
        }

        // ===== REAL ESTATE MEETODID =====
        public void UploadFilesToDatabase(RealEstateDto dto, RealEstate domain)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var image in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        var fileToDb = new FileToDatabase
                        {
                            Id = Guid.NewGuid(),
                            ImageTitle = image.FileName,
                            RealEstateId = domain.Id
                        };

                        image.CopyTo(target);
                        fileToDb.ImageData = target.ToArray();

                        _context.FileToDatabases.Add(fileToDb);
                    }
                }

                _context.SaveChanges();
            }
        }

        public async Task<FileToDatabase> RemoveImageFromDatabase(FileToDatabaseDto dto)
        {
            var image = await _context.FileToDatabases
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (image != null)
            {
                _context.FileToDatabases.Remove(image);
                await _context.SaveChangesAsync();
            }

            return image;
        }

        public async Task<FileToDatabase> RemoveImagesFromDatabase(FileToDatabaseDto[] dtos)
        {
            foreach (var dto in dtos)
            {
                var image = await _context.FileToDatabases
                    .FirstOrDefaultAsync(x => x.Id == dto.Id);

                if (image != null)
                {
                    _context.FileToDatabases.Remove(image);
                }
            }

            await _context.SaveChangesAsync();
            return null;
        }
    }
}