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
            var x = "C:\\Users\\ghine\\Pictures\\Bikes\\FOCUS.png";
            var fileHelper = new FileServiceProxy();
            fileHelper.IsAuthorized = true;
            fileHelper.CopyFile(x);
            fileHelper.DeleteFile("FOCUS_copy.png");

            var fileHelper2 = new FileServiceFacade();
            fileHelper2.CopyFile(x);
            fileHelper2.DeleteFile("FOCUS_copy.png");

            IBike b = new MTBBike()
            {
                Manufacturer = "FOCUS",
                Price = 3500,
                Model = "HighLand Peak",
                Year = 2014,
                WarrantyMonths = 24,
                Suspension = "SR Sountour",
                Specification = "Duralumin frame"

            };

            Console.WriteLine("Initial warranty: "+ b.GetWarrantyMonths());

            b = new ExtendedWarrantyBike(b)
            {
                ExtraPrice = 250,
                ExtraWarrantyMonths = 12
                
            };
            Console.WriteLine("Extended warranty: "+ b.GetWarrantyMonths());
            


        }
    }
}