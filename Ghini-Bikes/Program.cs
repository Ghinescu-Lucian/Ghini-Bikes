using Domain.Bikes;
using Domain.Exceptions;
using Domain.Models;
using Domain.Products;
using Domain.Users;
using System.Diagnostics;
using System;
using Ghini_Bikes.Services;
using Domain.ProductFactory;
using Domain.Orders;

namespace Bikes
{
    class Program
    {
        static void Main(string[] args)
        {

            NormalUser u = new NormalUser("Luky", "1234", "luky@gmail.com", "image1.png");
            u.LogIn("1234");

            MTBBike b = new MTBBike()
            {
                Manufacturer = "FOCUS",
                Price = 3500,
                Model = "HighLand Peak",
                Year = 2014,
                WarrantyMonths = 24,
                Suspension = "SR Sountour",
                Specification = "Duralumin frame"

            };
            Accesory a = new Accesory()
            {
                Manufacturer = "Sram",
                Year = 2022,
                Model = "Ring",
                Description = "Claxon",
                Price = 20

            };

           
           
           
            u.AddToCart(a);
           Order order = u.Place_Order("Personal");
            Console.WriteLine(order);
          
            u.AddToCart(a);
            Order order1 = u.Place_Order("Courier");
            Console.WriteLine(order1);

            u.AddToCart(a);
             u.AddToCart(b);
            Order order2 = u.Place_Order("Courier");
            Console.WriteLine(order2);


        }
    }
}