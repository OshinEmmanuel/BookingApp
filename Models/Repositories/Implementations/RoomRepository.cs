using BookingApp.Models.Context;
using BookingApp.Models.Entities;
using BookingApp.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Models.Repositories.Implementations
{
    public class RoomRepository : IRoomRepository
    {
        protected readonly ApplicationDBContext _dbContext;

        public RoomRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public Room AddRoom(Room room)
        {
            _dbContext.Rooms.Add(room);
            _dbContext.SaveChanges();
            return room;
        }

        public void DeleteRoom(Room room)
        {
            _dbContext.Rooms.Remove(room);
            _dbContext.SaveChanges();
        }

        public List<Room> GetAllRooms()
        {
            var rooms = _dbContext.Rooms.ToList();
            return rooms;
        }

        public Room GetRoom(int id)
        {
            var room = _dbContext.Rooms.Find(id);
            return room;
        }

        public Room UpdateRoom(Room room)
        {
            _dbContext.Rooms.Update(room);
            _dbContext.SaveChanges ();
            return room;
        }
    }
}
