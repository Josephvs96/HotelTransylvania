using HotelTransylvania.Models;
using System.Collections.Generic;
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

            var singleRoomType = new RoomType { Type = Enums.RoomTypes.Single, Description = "A single room" };
            var doubleRoomType = new RoomType { Type = Enums.RoomTypes.Double, Description = "A double room" };

            var rooms = new List<Room>
            {
                new Room { RoomNumber = 100, IsAvailble = true, IsActive=true, PricePerNight = 750.00m, RoomType = doubleRoomType,
                    RoomProperties = new RoomProperties
                    {
                        RoomSize=50.00m,
                        ExtraBeds = new ExtraBeds(doubleRoomType, 1)
                    }
                },
                new Room { RoomNumber = 101, IsAvailble = true, IsActive=true, PricePerNight = 500.00m, RoomType=singleRoomType,
                     RoomProperties = new RoomProperties
                     {
                        RoomSize=25.00m,
                        ExtraBeds = new ExtraBeds(singleRoomType)
                     }
                },
                new Room { RoomNumber = 102, IsAvailble = true, IsActive=true, PricePerNight = 750.00m, RoomType = doubleRoomType,
                    RoomProperties = new RoomProperties
                    {
                        RoomSize=75.00m,
                        ExtraBeds = new ExtraBeds(doubleRoomType, 2)
                    }
                },
                new Room { RoomNumber = 103, IsAvailble = true, IsActive=true, PricePerNight = 500.00m, RoomType=singleRoomType,
                     RoomProperties = new RoomProperties
                     {
                        RoomSize=25.00m,
                        ExtraBeds = new ExtraBeds(singleRoomType)
                     }
                },
                new Room { RoomNumber = 104, IsAvailble = true, IsActive=true, PricePerNight = 750.00m, RoomType = doubleRoomType,
                    RoomProperties = new RoomProperties
                    {
                        RoomSize=50.00m,
                        ExtraBeds = new ExtraBeds(doubleRoomType, 1)
                    }
                },
                new Room { RoomNumber = 105, IsAvailble = true, IsActive=true, PricePerNight = 500.00m, RoomType=singleRoomType,
                     RoomProperties = new RoomProperties
                     {
                        RoomSize=25.00m,
                        ExtraBeds = new ExtraBeds(singleRoomType)
                     }
                },
                 new Room { RoomNumber = 106, IsAvailble = true, IsActive=true, PricePerNight = 750.00m, RoomType = doubleRoomType,
                    RoomProperties = new RoomProperties
                    {
                        RoomSize=75.00m,
                        ExtraBeds = new ExtraBeds(doubleRoomType, 2)
                    }
                },
            };

            context.Rooms.AddRange(rooms);
            context.SaveChanges();
        }
    }
}
