using Newtonsoft.Json;
using SpeedyAir.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir.Data
{
    public class ApplicationContext: IApplicationContext
    {
        /// <summary>
        /// Load Orders From Json
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<Order> LoadOrdersFromJson(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Order JSON file not found.");
                return new List<Order>();
            }

            var jsonData = File.ReadAllText(filePath);
            var ordersData = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonData);
            return ordersData.Select(o => new Order { OrderID = o.Key, Destination = o.Value.destination }).ToList();
        }
    }
}
