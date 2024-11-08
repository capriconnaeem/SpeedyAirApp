using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir.Entities.Flight
{
    /// <summary>
    /// Represents a flight with destination, departure, and scheduled day.
    /// </summary>
    public class Flight
    {
        /// <summary>
        /// Get and set FlightNumber
        /// </summary>
        public int FlightNumber { get; set; }
        /// <summary>
        /// Get and set Departure
        /// </summary>
        public string Departure { get; set; } = "YUL";  // Default departure location
        /// <summary>
        /// Get and set Arrival
        /// </summary>
        public string Arrival { get; set; }
        /// <summary>
        /// Get and set Day
        /// </summary>
        public int Day { get; set; }
        /// <summary>
        /// Get and set Capacity
        /// </summary>
        public int Capacity { get; set; } = 20;         // Fixed capacity per flight
        /// <summary>
        /// Get and set list of Orders
        /// </summary>
        public List<Order.Order> AssignedOrders { get; set; } = new List<Order.Order>();
        /// <summary>
        /// Check Order to load
        /// </summary>
        /// <returns></returns>
        public bool IsLoadOrder()
        {
            return AssignedOrders.Count < Capacity;
        }
    }
}
