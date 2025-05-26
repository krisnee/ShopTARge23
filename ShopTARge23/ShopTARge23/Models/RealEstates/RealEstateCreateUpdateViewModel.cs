using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ShopTARge23.Models.RealEstates
{
    public class RealEstateCreateUpdateViewModel
    {
        public Guid? Id { get; set; }

        [Required]
        [Display(Name = "Size (m²)")]
        [Range(1, 10000, ErrorMessage = "Size must be between 1 and 10000 m²")]
        public double? Size { get; set; }

        [Required]
        [Display(Name = "Location")]
        [StringLength(200, ErrorMessage = "Location cannot exceed 200 characters")]
        public string? Location { get; set; }

        [Required]
        [Display(Name = "Room Number")]
        [Range(1, 50, ErrorMessage = "Room number must be between 1 and 50")]
        public int? RoomNumber { get; set; }

        [Required]
        [Display(Name = "Building Type")]
        [StringLength(100, ErrorMessage = "Building type cannot exceed 100 characters")]
        public string? BuildingType { get; set; }

        [Display(Name = "Images")]
        public List<IFormFile>? Files { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}