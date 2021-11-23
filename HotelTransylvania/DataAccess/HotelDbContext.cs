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
    }
}
