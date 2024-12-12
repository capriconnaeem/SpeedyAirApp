using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SpeedyAir.BusinessLogic.Area.Services;
using SpeedyAir.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir.ConsoleApp.ServiceExtensions
{
    public static class CommonServiceExtensions
    {
        /// <summary>
        /// Add Services
        /// </summary>
        /// <returns></returns>
        public static ServiceProvider AddServices()
        {
            // Add logging configuration
            return new ServiceCollection()
           .AddSingleton<IApplicationContext, ApplicationContext>()
           .AddSingleton<IFlightService, FlightService>()
           .AddSingleton<IOrderService, OrderService>()
           .AddLogging(configure => configure.AddConsole().SetMinimumLevel(LogLevel.Information))
           .BuildServiceProvider();
        }
    }
}
