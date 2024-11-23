using BookingApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingApp.Models.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {
        }
        public DbSet<Room> Rooms { get; set; }

        public DbSet<Flight> Flights { get; set; }
    }

}
