using SpeedyAir.Entities.Common;
using SpeedyAir.Entities.Flight;
using SpeedyAir.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir.BusinessLogic.Area.Services
{
    public interface IOrderService
    {
        Task<BusinessResultWithData<IEnumerable<Order>>> AssignOrdersToFlights(List<Flight> flights, List<Order> orders);
    }
}
