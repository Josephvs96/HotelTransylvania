using System.Linq;


namespace HotelTransylvania.DataAccess
{
    public static class DbInitializer
    {
        public static void Initialize(HotelDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Rooms.Any())
            {
                return;   // DB has been seeded, dont touch it!
            }

            // Seed some data here ...

        }
    }
}
