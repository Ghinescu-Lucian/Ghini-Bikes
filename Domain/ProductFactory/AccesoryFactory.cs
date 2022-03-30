using Domain.Bikes;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProductFactory
{
    public class AccesoryFactory : IProductFactory
    {
        private static AccesoryFactory _instance;
        private static readonly object padlock = new object();

        private AccesoryFactory()
        {
            //System.Console.WriteLine("Constructor called");
        }

        public static AccesoryFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    //System.Console.WriteLine("Instance called");
                    lock (padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new AccesoryFactory();
                        }
                    }
                }
                return _instance;
            }
            private set { }
        }
        public Product CreateProduct(int year, double price, string model, string manufacturer, string description)
        {
            return new Accessory
            {
                Year = year,
                Price = price,
                Manufacturer = manufacturer,
                Description = description,
                Model = model
            };
            
        }

       
    }
}
