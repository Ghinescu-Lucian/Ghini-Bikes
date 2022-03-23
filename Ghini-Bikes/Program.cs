//#define CONDITION
using Domain.Bikes;
using Domain.Exceptions;
using Domain.Models;
using Domain.Products;
using Domain.Users;
using System.Diagnostics;
using System;
using Ghini_Bikes.Services;

namespace Bikes
{
    class Program
    {
        static void Main(string[] args)
        {
#if CONDITION
            Console.WriteLine("Conditional compilation");
#endif
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

            Console.WriteLine();

            NormalUser u = new NormalUser("Luky", "1234", "l@k.com","1.jpg");
          
            try
            {
                 //double t = u.GetTotalPrice();
                u.LogIn("1234");
               // u.AddToCart(null);
            }
            catch(EmptyCartException ex)
            {
                Debug.WriteLine($"{ex.Message}");
                Console.WriteLine($"{ex.Message}");
            }
            catch(InvalidCredentialsException ex1){
                Debug.WriteLine(ex1.Message);
                Console.WriteLine(ex1.Message);
            }
            catch(ArgumentNullException ex2)
            {
                Debug.WriteLine(" Null parameter found!");
                Console.WriteLine(" Null parameter found!");
                throw new Exception("Program crashed!", ex2);
            }
            finally
            {
                Console.WriteLine();
                u.AddToCart(a);
                u.AddToCart(a);
                u.AddToCart(pack);
                //Console.WriteLine(u.ToString());
               // Console.WriteLine(u.GetTotalPrice());
            }

            Console.WriteLine();
            u.Place_Order();
            Console.WriteLine();
            Console.WriteLine("HashSet:");
            Product[] p = u.GetOrder().GetHashSet();
            for(int i=0;i < p.Length; i++)
            {
                Console.WriteLine(p[i].ToString());
            }

            var filePath1 = "C:\\Users\\ghine\\Pictures\\Bikes\\FOCUS.png";
            var filePath2 = "C:\\Users\\ghine\\Desktop\\Facultate\\Sem6\\PNS\\Laborator\\Laborator 3\\lab4.m";
            FileService.CopyFile(filePath2);
            FileService.CopyPicture(filePath1);

            filePath1 = "C:\\Users\\ghine\\Desktop\\Facultate\\Amdaris\\Proiect\\Ghini-Bike\\Ghini-Bikes\\Ghini-Bikes\\Pictures\\FOCUS_copy.png";
            filePath2 = "C:\\Users\\ghine\\Desktop\\Facultate\\Amdaris\\Proiect\\Ghini-Bike\\Ghini-Bikes\\Ghini-Bikes\\Pictures\\lab4_copy.m";
            FileService.DeleteFile(filePath2);
            FileService.DeleteFile(filePath1);




        }
    }
}