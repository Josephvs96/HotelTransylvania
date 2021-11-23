﻿using HotelTransylvania.DataAccess;
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

        }

    }
}
