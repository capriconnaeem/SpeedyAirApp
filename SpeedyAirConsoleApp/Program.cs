﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SpeedyAir.BusinessLogic.Area.Services;
using SpeedyAir.ConsoleApp.App;
using SpeedyAir.ConsoleApp.Configs;
using SpeedyAir.ConsoleApp.ServiceExtensions;
using SpeedyAir.Data;
using SpeedyAir.Entities.Order;

class Program
{
    private static IConfiguration _configuration;

    static void Main()
    {
        //Load Configuration
        _configuration = CommonConfigExtensions.AddConfigurations();

        // Set up Dependency Injection and Logging
        var serviceProvider = CommonServiceExtensions.AddServices();

        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogInformation("Application Starting");

        try
        {
            // Run the main program logic
            Application.StartApplication(serviceProvider,_configuration);
            Console.WriteLine("End");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while running the application");
        }
        finally
        {
            logger.LogInformation("Application Stopping");
        }
    }
}