using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpeedyAir.BusinessLogic.Area.Services;
using SpeedyAir.Data;
using SpeedyAir.Entities.Flight;
using SpeedyAir.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir.ConsoleApp.App
{
    public static class Application
    {
        public static async void StartApplication(IServiceProvider serviceProvider, IConfiguration _configuration)
        {
            try
            {
                var flightService = serviceProvider.GetRequiredService<IFlightService>();
                var flights = await flightService.GetFlightsInformation();

                if (flights.StatusCode == System.Net.HttpStatusCode.OK && flights.Data != null)
                {
                    // Display flights
                    DisplayFlights(flights.Data);

                    // Load orders datils form Json file
                    var filePath = _configuration["OrderData:JsonFilePath"];
                    var contextService = serviceProvider.GetRequiredService<IApplicationContext>();
                    var orders = contextService.LoadOrdersFromJson(filePath);

                    // Load orders and schedule them
                    var orderService = serviceProvider.GetRequiredService<IOrderService>();

                    var assignedOrderList = await orderService.AssignOrdersToFlights(flights.Data.ToList(), orders);
                    if (assignedOrderList.StatusCode == System.Net.HttpStatusCode.OK && assignedOrderList.Data != null)
                    {
                        // Display Display Assign Orders To Flights
                        DisplayAssignOrdersToFlights(assignedOrderList.Data);
                    }
                }
                else
                {
                    Console.WriteLine(flights.ErrorMessage);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }

        }
        private static void DisplayFlights(IEnumerable<Flight> flights)
        {

            try
            {
                if (flights.Count() > 0)
                {
                    Console.WriteLine("User Story 1: Flight Schedule");
                    foreach (var flight in flights)
                    {
                        Console.WriteLine($"Flight: {flight.FlightNumber}, From: {flight.Departure}, To: {flight.Arrival}, Day: {flight.Day}");
                    }
                }
                else
                {
                    Console.WriteLine("Unable to found any flight");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }
        private static void DisplayAssignOrdersToFlights(IEnumerable<Order> assignedOrderList)
        {
            try
            {
                Console.WriteLine("User Story 2: Assign Orders To Flight Schedule");
                foreach (var order in assignedOrderList)
                {
                    if (order.FlightNumber != -1)
                    {
                      
                        Console.WriteLine($"Order: {order.OrderID}, FlightNumber: {order.FlightNumber}, Departure: YUL, Arrival: {order.Destination}, Day: {(order.FlightNumber <= 3 ? 1 : 2)}");
                    }
                    else
                    {
                        Console.WriteLine($"Order: {order.OrderID}, FlightNumber: not scheduled");
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }
    }
}
