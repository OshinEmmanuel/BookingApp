using BookingApp.Models.Entities;

namespace BookingApp.Models.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        Room GetRoom(int id);
        List<Room> GetAllRooms();

       Room AddRoom(Room room);
       Room UpdateRoom(Room room);
       void DeleteRoom(Room room);

    }
}
