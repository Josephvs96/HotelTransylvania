using HotelTransylvania.DataAccess;
using HotelTransylvania.Interfaces;
using HotelTransylvania.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HotelTransylvania
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
            services.AddSingleton<Startup>();
            services.AddSingleton<ConsoleUIService>();
            services.AddSingleton<IGuestService, GuestService>();
        }
    }
}
