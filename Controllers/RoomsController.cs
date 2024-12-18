﻿using BookingApp.Models.Context;
using BookingApp.Models.DTOs;
using BookingApp.Models.Entities;
using BookingApp.Models.Helpers;
using BookingApp.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RoomsController(IRoomRepository roomRepository, IWebHostEnvironment webHostEnvironment)
        {
            _roomRepository = roomRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var rooms = _roomRepository.GetAllRooms();
            return View(rooms);
        }

        public IActionResult GetRoom(int id)
        {
            var room = _roomRepository.GetRoom(id);
            return View(room);
        }

        public IActionResult AddRoom()
        {
            return View(); 
                    
        }
        [HttpPost]
        public IActionResult AddRoom(RoomDTO model)
        {
           
            var room = new Room
            {
                RoomTitle = model.RoomTitle, 
                City = model.City,
                Country = model.Country,
                Description = model.Description,
                Price = model.Price,
                RoomOwner   = model.RoomOwner,
                RoomAddress = model.RoomAddress,
                RoomType = model.RoomType,
                IsActive    = model.IsActive,
                Rating = model.Rating,
            };
            List<Image> images = new List<Image>();
            foreach (var image in model.Images)
            {
                //creating a directory to save the file. this will create a folder in the wwwroot
                string roomDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "rooms");
                Directory.CreateDirectory(roomDirectory);

                string contentType = image.ContentType.Split('/')[1];
                string fileName = $"{Guid.NewGuid()}.{contentType}";
                string fullPath = Path.Combine(roomDirectory, fileName);
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }

                var img = new Image
                {
                    Url = $"rooms/{fileName}",
                    RoomID = room.ID,
                };
                images.Add(img);
            }
            room.Images = images;
            _roomRepository.AddRoom(room);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateRoom(int id)
        {
            var room = _roomRepository.GetRoom(id);
            if (room == null)
            {
                return NotFound(); // Handle the case where the room is not found
            }

            var model = new RoomDTO
            {
                ID = room.ID,
                RoomTitle = room.RoomTitle,
                City = room.City,
                Country = room.Country,
                Description = room.Description,
                Price = room.Price,
                RoomOwner = room.RoomOwner,
                RoomAddress = room.RoomAddress,
                RoomType = room.RoomType,
                Rating = room.Rating,

            };

            return View(model); // Pass the model to the view for editing
        }

        [HttpPost]
        public IActionResult UpdateRoom(RoomDTO model)
        {
            if (ModelState.IsValid)
            {
                var room = _roomRepository.GetRoom(model.ID);
                if (room == null)
                {
                    return NotFound();
                }

                room.RoomTitle = model.RoomTitle;
                room.City = model.City;
                room.Country = model.Country;
                room.Description = model.Description;
                room.Price = model.Price;
                room.RoomOwner = model.RoomOwner;
                room.RoomAddress = model.RoomAddress;
                room.RoomType = model.RoomType;
                room.Rating = model.Rating;
                _roomRepository.UpdateRoom(room); // Save changes to the repository

                return RedirectToAction("Index");
            }

            return View(model); // Return the view with validation errors
        }


    }


}
