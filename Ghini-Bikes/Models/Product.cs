using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghini_Bikes.Models
{
    public class Product
    {
        private string manufacturer;
        private string model;
        private double price;
        private int year;
        public int Year { get { return year; } set { year = value; } }
        public double Price { get { return price; } set { price = value; } }
        public string Manufacturer { get { return manufacturer; } set { manufacturer = value; } }
        public string Model { get { return model; } set { model = value; } }

        public override string ToString()
        {
            string s = manufacturer + " " + model + " " + price;
            return s;
        }
    }
}
