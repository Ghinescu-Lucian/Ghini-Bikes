using Ghini_Bikes.Bikes;
using System;

namespace Bikes
{
    class Program
    {
        static void Main(string[] args)
        {
            Bike a;
            ElectricBike b;
            MTBBike c;
            MTBBike d;

            Accesory acc = new Accesory("Trelock","LS-460",275,"Faruri USB I-GO");
            PromoPackage pack = new PromoPackage();

            a = new Bike("Focus", "Raven", 2019, "Carbon frame",4500);
            b = new ElectricBike("Cube", "Stereo Hybrid", 2022,"Duralumin frame",9000,650);
            c = new MTBBike("Scott", "Scale 960", 2021, "Duralumin frame",3500,"RockShox");
            d= (MTBBike)c.Clone();
            pack.AddProduct(c);
            pack.AddProduct(acc);

            Console.WriteLine(a.ToString());
            Console.WriteLine(b.ToString());
            Console.WriteLine(c.ToString());
            Console.WriteLine();
            Console.WriteLine($"{a.Manufacturer}"+ " : " + $"{a.Coeficient().ToString("0.00")}");
            Console.WriteLine($"{b.Manufacturer}" + " :  " + $"{b.Coeficient(2).ToString("0.00")}");
            Console.WriteLine($"{c.Manufacturer}" + " : " + $"{c.Coeficient(3).ToString("0.00")}");
            Console.WriteLine($"{d.Manufacturer}" + " : " + $"{d.Coeficient(3).ToString("0.00")}");

            Console.WriteLine($"{pack.ToString()}");



        }
    }
}