using Microsoft.Extensions.Logging;
using SpeedyAir.Entities.Common;
using SpeedyAir.Entities.Flight;

namespace SpeedyAir.BusinessLogic.Area.Services
{
    /// <summary>
    /// Provides methods for managing flights and scheduling orders.
    /// </summary>
    public class FlightService : IFlightService
    {
        private readonly ILogger<FlightService> _logger;

        public FlightService(ILogger<FlightService> logger)
        {
            _logger = logger;

        }

        /// <summary>
        /// Get All Flights
        /// </summary>
        /// <returns></returns>
        public async Task<BusinessResultWithData<IEnumerable<Flight>>> GetFlightsInformation()
        {
            _logger.LogInformation("Start method to get all flights.");

            var response = new BusinessResultWithData<IEnumerable<Flight>>() { StatusCode = System.Net.HttpStatusCode.OK };
            try
            {
                var _flights = new List<Flight>
            {
                new Flight { FlightNumber = 1, Arrival = "YYZ", Day = 1 },
                new Flight { FlightNumber = 2, Arrival = "YYC", Day = 1 },
                new Flight { FlightNumber = 3, Arrival = "YVR", Day = 1 },
                new Flight { FlightNumber = 4, Arrival = "YYZ", Day = 2 },
                new Flight { FlightNumber = 5, Arrival = "YYC", Day = 2 },
                new Flight { FlightNumber = 6, Arrival = "YVR", Day = 2 }
            };
                _logger.LogInformation($"End method to  Complete all flights. Number of flights: {_flights.Count()}");
                response.Data = _flights;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Message:", ex.Message);
                response.ErrorMessage = ex.Message;
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            }
            return response;
        }
    }
}
