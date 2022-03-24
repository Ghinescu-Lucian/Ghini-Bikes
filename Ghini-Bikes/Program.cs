using Domain.Bikes;
using Domain.Exceptions;
using Domain.Models;
using Domain.Products;
using Domain.Users;
using System.Diagnostics;
using System;
using Ghini_Bikes.Services;
using Domain.ProductFactory;

namespace Bikes
{
    class Program
    {
        static void Main(string[] args)
        {
            var bikeFactory = BikeFactory.Instance;
            var partfactory = PartFactory.Instance;
            var accesoryFactory = AccesoryFactory.Instance;

            MTBBike a = (MTBBike)bikeFactory.CreateProductOfType("MTBBike", 2022, 4500, "Whistler", "FOCUS","Duralumin frame");
            ElectricBike b = (ElectricBike)bikeFactory.CreateProductOfType("ElectricBike", 2022, 12000, "Stereo Hybrid", "Cube", "Battery 900wh");
            Part p = (Part)partfactory.CreateProduct(2020, 120, "Ultegra", "Shimano", " Steel chain");
            Accesory acc = (Accesory)accesoryFactory.CreateProduct(2022, 275, "LS-460", "Trelock", " USB lights I-GO");
            PromoPackage pack = new PromoPackage();
            pack.AddProduct(a);
            pack.AddProduct(p);
            pack.AddProduct(acc);
            Console.WriteLine(pack.ToString());

        }
    }
}