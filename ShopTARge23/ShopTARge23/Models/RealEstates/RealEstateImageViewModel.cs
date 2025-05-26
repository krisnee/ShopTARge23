namespace ShopTARge23.Models.RealEstates
{
    public class RealEstateImageViewModel
    {
        public Guid ImageId { get; set; }
        public string? ImageTitle { get; set; }
        public byte[]? ImageData { get; set; }

        public string Image => Convert.ToBase64String(ImageData ?? Array.Empty<byte>());
        public Guid? RealEstateId { get; set; }
    }
}