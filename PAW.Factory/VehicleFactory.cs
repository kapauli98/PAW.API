using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW.Factory
{
    public class VehicleFactory
    {
        public static IVehicle Create(string name)
        {
            return name switch
            {
                "toyota" => new Toyota().Create(),
                "ford" => new Ford().Create(),
                "honda" => new Honda().Create(),
                _ => new Toyota(),
            };
        }
    }
}
