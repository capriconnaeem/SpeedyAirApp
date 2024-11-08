using SpeedyAir.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir.Entities.Order
{
    /// <summary>
    /// Represents an order, including its unique identifier and destination.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Get and Set OrderID
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// Get and set Destination
        /// </summary>
        public string Destination { get; set; }
        /// <summary>
        /// Get and set FlightNumber
        /// </summary>
        public int FlightNumber { get; set; } = -1; // -1 means not assigned


    }
}
