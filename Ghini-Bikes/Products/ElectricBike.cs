using Ghini_Bikes.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghini_Bikes.Bikes
{
    public class ElectricBike : Bike
    {
        private double batteryCapacity;

        public double BikeCapacity { get { return batteryCapacity; } set { batteryCapacity = value; } }
        public ElectricBike(string man, string model, int year, string specs,double price,double batteryCapacity) : base(man, model, year, specs,price)
        {
            BikeCapacity = batteryCapacity;
        }
        public override string ToString()
        {
            string s = "I'm an electric bike!";
            return s;
        }
        public double Coeficient(int soldNo)
        {
            double coef = base.Coeficient();
            if (soldNo > 0)
                coef += soldNo;
            return coef;

        }
    }
}
