using Microsoft.AspNetCore.Mvc;
using ShopTARge23.Core.Dto;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.Models.RealEstates;

namespace ShopTARge23.Controllers
{
    public class RealEstatesController  : Controller
    {
        private readonly IRealEstateServices _realEstateServices;
        private readonly IFileServices _fileServices;

        public RealEstatesController (
            IRealEstateServices realEstateServices,
            IFileServices fileServices)
        {
            _realEstateServices = realEstateServices;
            _fileServices = fileServices;
        }

        // GET: RealEstates
        public async Task<IActionResult> Index()
        {
            var realEstates = await _realEstateServices.GetAllAsync();

            var vm = realEstates.Select(x => new RealEstateIndexViewModel
            {
                Id = x.Id,
                Size = x.Size,
                Location = x.Location,
                RoomNumber = x.RoomNumber,
                BuildingType = x.BuildingType,
                CreatedAt = x.CreatedAt,
                ModifiedAt = x.ModifiedAt
            }).ToList();

            return View(vm);
        }

        // GET: RealEstates/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var realEstate = await _realEstateServices.GetAsync(id);
            if (realEstate == null)
            {
                return NotFound();
            }

            var vm = new RealEstateDetailsViewModel
            {
                Id = realEstate.Id ?? Guid.Empty,
                Size = (int)(realEstate.Size ?? 0),
                Location = realEstate.Location,
                RoomNumber = (int)(realEstate.RoomNumber ?? 0),
                BuildingType = realEstate.BuildingType,
                CreatedAt = realEstate.CreatedAt ?? DateTime.MinValue,
                ModifiedAt = realEstate.ModifiedAt ?? DateTime.MinValue,
            };

            return View(vm);
        }

        // GET: RealEstates/Create
        public IActionResult Create()
        {
            var vm = new RealEstateCreateUpdateViewModel();
            return View("CreateUpdate", vm);
        }

        // POST: RealEstates/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RealEstateCreateUpdateViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var dto = new RealEstateDto
                {
                    Size = vm.Size,
                    Location = vm.Location,
                    RoomNumber = vm.RoomNumber,
                    BuildingType = vm.BuildingType,
                    Files = vm.Files,
                    CreatedAt = DateTime.Now,
                    ModifiedAt = DateTime.Now
                };

                var result = await _realEstateServices.Create(dto);
                return RedirectToAction(nameof(Index));
            }

            return View("CreateUpdate", vm);
        }

        // GET: RealEstates/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var realEstate = await _realEstateServices.GetAsync(id);
            if (realEstate == null)
            {
                return NotFound();
            }

            var vm = new RealEstateCreateUpdateViewModel
            {
                Id = realEstate.Id,
                Size = realEstate.Size,
                Location = realEstate.Location,
                RoomNumber = realEstate.RoomNumber,
                BuildingType = realEstate.BuildingType,
                CreatedAt = realEstate.CreatedAt,
                ModifiedAt = realEstate.ModifiedAt
            };

            return View("CreateUpdate", vm);
        }

        // POST: RealEstates/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, RealEstateCreateUpdateViewModel vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var dto = new RealEstateDto
                {
                    Id = vm.Id,
                    Size = vm.Size,
                    Location = vm.Location,
                    RoomNumber = vm.RoomNumber,
                    BuildingType = vm.BuildingType,
                    Files = vm.Files,
                    CreatedAt = vm.CreatedAt,
                    ModifiedAt = DateTime.Now
                };

                await _realEstateServices.Update(dto);
                return RedirectToAction(nameof(Index));
            }

            return View("CreateUpdate", vm);
        }

        // GET: RealEstates/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var realEstate = await _realEstateServices.GetAsync(id);
            if (realEstate == null)
            {
                return NotFound();
            }

            var vm = new RealEstateDeleteViewModel
            {
                Id = realEstate.Id,
                Size = realEstate.Size,
                Location = realEstate.Location,
                RoomNumber = realEstate.RoomNumber,
                BuildingType = realEstate.BuildingType,
                CreatedAt = realEstate.CreatedAt,
                ModifiedAt = realEstate.ModifiedAt
            };

            return View(vm);
        }

        // POST: RealEstates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _realEstateServices.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}