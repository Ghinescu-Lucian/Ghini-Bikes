using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghini_Bikes.Bikes
{
    public abstract class Product
    {
        private string manufacturer;
        private string model;
        private double price;
        public double Price { get { return price; } set { price = value; } }
        public string Manufacturer { get { return manufacturer; } set { manufacturer = value; } }
        public string Model { get { return model; } set { model = value; } }
    }
}
