using HotelTransylvania.DataAccess;
using HotelTransylvania.Interfaces;
using HotelTransylvania.Services;
using HotelTransylvania.UI.BookingMenu;
using HotelTransylvania.UI.GuestMenu;
using HotelTransylvania.UI.MainMenu;
using HotelTransylvania.UI.RoomMenu;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;

namespace HotelTransylvania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var host = CreateHostBuilder(args).Build();
            var serviceScope = host.Services.CreateScope();

            // Make sure the database hase been created and has data in it
            var dbContext = serviceScope.ServiceProvider.GetService<HotelDbContext>();
            DbInitializer.Initialize(dbContext);

            // Starts the old bookings cleaning service
            var oldBookingsCleaningService = serviceScope.ServiceProvider.GetService<NotPayedBookingsCleanerService>();
            Thread bookingsCleanerThread = new Thread(new ParameterizedThreadStart(oldBookingsCleaningService.CleanOldBookings))
            {
                IsBackground = true,
                Name = "Old bookings cleaner thread"
            };

            Int32 sleepTime = 60 * 60;
            bookingsCleanerThread.Start(sleepTime);

            var startup = serviceScope.ServiceProvider.GetService<Startup>();
            startup.Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureServices(ConfigureServices);
        }

        private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            var config = context.Configuration;
            services.AddDbContext<HotelDbContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddSingleton<ConsoleUIService>();


            services.AddTransient<IGuestService, GuestService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IBookingService, BookingService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<Startup>();

            // Menues
            services.AddTransient<MainMenu>();
            services.AddTransient<GuestMenu>();
            services.AddTransient<RoomsMenu>();
            services.AddTransient<BookingMenu>();

            services.AddScoped<NotPayedBookingsCleanerService>();
        }
    }
}
