using HotelTransylvania.DataAccess;
using HotelTransylvania.Interfaces;
using HotelTransylvania.Services;
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

            services.AddScoped<Startup>();
            services.AddScoped<IGuestService, GuestService>();
            services.AddScoped<IRoomService, RoomService>();

            // Menues
            services.AddScoped<MainMenuCollection>();
            services.AddScoped<GuestMenuCollection>();
            services.AddScoped<RoomsMenuCollection>();
        }
    }
}
