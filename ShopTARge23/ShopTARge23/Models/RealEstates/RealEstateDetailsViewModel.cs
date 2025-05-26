using ShopTARge23.Models.RealEstates;
using System;
using System.Collections.Generic;

namespace ShopTARge23.Models.RealEstates
{
    public class RealEstateDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Location { get; set; }
        public int Size { get; set; }
        public int RoomNumber { get; set; }
        public string BuildingType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public List<RealEstateImageViewModel> Images { get; set; } = new();
    }
}