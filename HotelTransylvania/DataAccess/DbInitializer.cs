using HotelTransylvania.Models;


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

            var singleRoomType = new RoomType { Type = CustomTypes.RoomTypes.Single, Description = "A single room" };
            var doubleRoomType = new RoomType { Type = CustomTypes.RoomTypes.Double, Description = "A double room" };

            var rooms = new List<Room>
            {
                new Room { RoomNumber = 100, IsActive=true, PricePerNight = 750.00m, RoomType = doubleRoomType,
                    RoomProperties = new RoomProperties
                    {
                        RoomSize=50.00m,
                        ExtraBeds = new ExtraBeds(doubleRoomType.Type, 1)
                    }
                },
                new Room { RoomNumber = 101, IsActive=true, PricePerNight = 500.00m, RoomType=singleRoomType,
                     RoomProperties = new RoomProperties
                     {
                        RoomSize=25.00m,
                        ExtraBeds = new ExtraBeds(singleRoomType.Type)
                     }
                },
                new Room { RoomNumber = 102, IsActive=true, PricePerNight = 750.00m, RoomType = doubleRoomType,
                    RoomProperties = new RoomProperties
                    {
                        RoomSize=75.00m,
                        ExtraBeds = new ExtraBeds(doubleRoomType.Type, 2)
                    }
                },
                new Room { RoomNumber = 103, IsActive=true, PricePerNight = 500.00m, RoomType=singleRoomType,
                     RoomProperties = new RoomProperties
                     {
                        RoomSize=25.00m,
                        ExtraBeds = new ExtraBeds(singleRoomType.Type)
                     }
                },
                new Room { RoomNumber = 104, IsActive=true, PricePerNight = 750.00m, RoomType = doubleRoomType,
                    RoomProperties = new RoomProperties
                    {
                        RoomSize=50.00m,
                        ExtraBeds = new ExtraBeds(doubleRoomType.Type, 1)
                    }
                },
                new Room { RoomNumber = 105, IsActive=true, PricePerNight = 500.00m, RoomType=singleRoomType,
                     RoomProperties = new RoomProperties
                     {
                        RoomSize=25.00m,
                        ExtraBeds = new ExtraBeds(singleRoomType.Type)
                     }
                },
                 new Room { RoomNumber = 106, IsActive=true, PricePerNight = 750.00m, RoomType = doubleRoomType,
                    RoomProperties = new RoomProperties
                    {
                        RoomSize=75.00m,
                        ExtraBeds = new ExtraBeds(doubleRoomType.Type, 2)
                    }
                },
            };

            context.Rooms.AddRange(rooms);
            context.SaveChanges();
        }
    }
}
