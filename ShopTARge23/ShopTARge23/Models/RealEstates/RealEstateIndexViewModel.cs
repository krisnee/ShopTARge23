using System.ComponentModel.DataAnnotations;

namespace ShopTARge23.Models.RealEstates
{
    public class RealEstateIndexViewModel
    {
        public Guid? Id { get; set; }

        [Display(Name = "Size (m²)")]
        public double? Size { get; set; }

        [Display(Name = "Location")]
        public string? Location { get; set; }

        [Display(Name = "Room Number")]
        public int? RoomNumber { get; set; }

        [Display(Name = "Building Type")]
        public string? BuildingType { get; set; }

        [Display(Name = "Created At")]
        public DateTime? CreatedAt { get; set; }

        [Display(Name = "Modified At")]
        public DateTime? ModifiedAt { get; set; }
    }
}
