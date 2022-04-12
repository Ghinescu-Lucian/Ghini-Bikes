using Domain.Bikes;
using Domain.Models;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProductFactory
{
    public class BikeFactory : IProductFactory<Bike>
    {

        private static BikeFactory _instance;
        private static readonly object padlock = new object();

        private BikeFactory()
        {
           // System.Console.WriteLine("Constructor called");
        }

        public static BikeFactory Instance
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
                            _instance = new BikeFactory();
                        }
                    }
                }
                return _instance;
            }
            private set { }
        }

        public Bike CreateProduct(int year, double price, string model, string manufacturer, string description)
        {
            return new Bike
            {
                Year = year,
                Price = price,
                Manufacturer = manufacturer,
                Description = description,
                Model = model,
                Category = 1
            };

        }
        public Bike CreateProductOfType(string type,int year, double price, string model, string manufacturer, string description)
        {
            switch (type)
            {
                case "MTBBike":
                    {
                        return new MTBBike
                        {
                            Year = year,
                            Price = price,
                            Manufacturer = manufacturer,
                            Description = description,
                            Model = model,
                            Category = 2
                        };
                        break;
                    }
                case "ElectricBike":
                    {
                        return new ElectricBike
                        {
                            Year = year,
                            Price = price,
                            Manufacturer = manufacturer,
                            Description = description,
                            Model = model,
                            Category = 3
                        };
                        break;
                    }
                case "Bike":
                    {
                        return CreateProduct(year, price, model, manufacturer, description);
                        break;
                    }
                default: throw new Exception("Unknown model of bike!");
            }
           
        }


        }
    }
