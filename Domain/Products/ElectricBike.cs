using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Bikes
{
    public class ElectricBike : Bike
    {
        private double batteryCapacity;

        public double BikeCapacity { get { return batteryCapacity; } set { batteryCapacity = value; } }
        public double Coeficient(int soldNo)
        {
            double coef = base.Coeficient();
            if (soldNo > 0)
                coef += soldNo;
            return coef;

        }
    }
}
