using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Bikes
{
    public class Accesory : Product
    {
        private string name;
        public string Name { get { return name; } set { this.name = value; } }

        public Accesory(string manufacturer, string model, double price, string name)
        {
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            Name = name;
        }
        public override string ToString()
        {
            string s = Manufacturer + " " + Model + " " + Price + " " + Name;
            return s;
        }
    }
}
