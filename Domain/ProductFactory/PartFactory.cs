using Domain.Models;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProductFactory
{
    public class PartFactory : IProductFactory
    {
        private static PartFactory _instance;
        private static readonly object padlock = new object();

        private PartFactory()
        {
           // System.Console.WriteLine("Constructor called");
        }

        public static PartFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                   // System.Console.WriteLine("Instance called");
                    lock (padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new PartFactory();
                        }
                    }
                }
                return _instance;
            }
            private set { }
        }
        public Product CreateProduct(int year, double price, string model, string manufacturer, string description)
        {
            return new Part
            {
                Manufacturer = manufacturer,
                Description = description,
                Year = year,
                Price = price,
                Model = model,
            };
        }
    }
}
