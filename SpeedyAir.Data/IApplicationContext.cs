using SpeedyAir.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir.Data
{
    public interface IApplicationContext
    {
        List<Order> LoadOrdersFromJson(string filePath);
    }
}
