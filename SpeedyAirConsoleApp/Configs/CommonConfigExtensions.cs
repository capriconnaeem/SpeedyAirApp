using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpeedyAir.BusinessLogic.Area.Services;
using SpeedyAir.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir.ConsoleApp.Configs
{
    public static class CommonConfigExtensions
    {
        public static IConfiguration AddConfigurations()
        {
            return new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();
        }
    }
}
