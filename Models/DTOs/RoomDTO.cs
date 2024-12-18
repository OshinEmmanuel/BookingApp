﻿using BookingApp.Models.Entities;
using System.Security.Policy;

namespace BookingApp.Models.DTOs
{
    public class RoomDTO
    {
        public int ID { get; set; }
        public required string Description { get; set; }
        public required string RoomTitle { get; set; }
        public required string RoomAddress { get; set; }
        public string City { get; set; } = default!;

        public string Country { get; set; } = null!;
        public decimal Price { get; set; }

        public int Rating { get; set; }

        public bool IsActive { get; set; }

        public RoomType RoomType { get; set; }

        public string RoomOwner { get; set; }

        public List <IFormFile> Images { get; set; }
    }
}
