using HotelTransylvania.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelTransylvania.DataAccess
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<RoomProperties> RoomProperties { get; set; }
        public DbSet<ExtraBeds> ExtraBeds { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
