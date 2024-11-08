using Microsoft.Extensions.Logging;
using SpeedyAir.Entities.Common;
using SpeedyAir.Entities.Flight;
using SpeedyAir.Entities.Order;

namespace SpeedyAir.BusinessLogic.Area.Services
{
    public class OrderService: IOrderService
    {
        private readonly ILogger<OrderService> _logger;

        public OrderService(ILogger<OrderService> logger)
        {
            _logger = logger;
        }
        public async Task<BusinessResultWithData<IEnumerable<Order>>> AssignOrdersToFlights(List<Flight> flights, List<Order> orders)
        {
            _logger.LogInformation("Starting order assignment to flights.");

            var response = new BusinessResultWithData<IEnumerable<Order>> { StatusCode = System.Net.HttpStatusCode.OK };
            try
            {
                if (orders == null || orders.Count == 0)
                {
                    _logger.LogWarning("No orders to assign.");
                    response.Data = orders;
                    return response;
                }

                foreach (var order in orders)
                {
                    var flight = flights.FirstOrDefault(f => f.Arrival == order.Destination && f.IsLoadOrder());

                    if (flight != null)
                    {
                        flight.AssignedOrders.Add(order);
                        order.FlightNumber = flight.FlightNumber;
                    }
                    else
                    {
                        order.FlightNumber = -1; // Mark as not scheduled
                    }
                }

                _logger.LogInformation($"Order assignment completed. Total flights processed: {flights.Count()}.");
                response.Data = orders;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during order assignment.");
                response.ErrorMessage = ex.Message;
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }
    }
}
