using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW.Factory
{
    public interface IVehicle
    {
        string Model { get; set; }
        int Wheels { get; set; }
        string Color { get; set; }
        int CC { get; set; }
        void Drive();
        IVehicle Create();
    }

    public abstract class Car : IVehicle
    {
        public string Model { get; set; }
        public int Wheels { get; set; }
        public string Color { get; set; }
        public int CC { get; set; }

        public void Drive()
        {
            return;
        }

        public IVehicle Create()
        {
            Model = "Gerenic";
            Wheels = 4;
            Color = "Green";
            CC = 1600;
            return this;
        }
    }

    public class Toyota : Car
    {

        public void Drive()
        {
            return;

        }
    }

    public class Ford : Car
    {
        public void Drive()
        {
            return;

        }
    }

    public class Honda : Car
    {
        public void Drive()
        {
            return;

        }
    }

}
