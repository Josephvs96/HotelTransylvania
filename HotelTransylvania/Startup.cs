using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting; 
namespace HotelTransylvania
{

    internal class Startup
    {
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) => { })
                .ConfigureAppConfiguration((context, appConfiguration) => appConfiguration.Build());
                    
        }
    }
}
