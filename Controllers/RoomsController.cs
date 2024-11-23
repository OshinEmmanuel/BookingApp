using BookingApp.Models.Context;
using BookingApp.Models.DTOs;
using BookingApp.Models.Entities;
using BookingApp.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomRepository _roomRepository;

        public RoomsController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
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
                IsActive    = true
            };
            _roomRepository.AddRoom(room);
            return RedirectToAction("Index");
        }
        

    }


}
