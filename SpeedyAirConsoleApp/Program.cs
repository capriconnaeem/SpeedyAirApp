using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SpeedyAir.ConsoleApp.App;
using SpeedyAir.ConsoleApp.Configs;
using SpeedyAir.ConsoleApp.ServiceExtensions;

class Program
{
    private static IConfiguration _configuration;
    /// <summary>
    /// Main method start
    /// </summary>
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