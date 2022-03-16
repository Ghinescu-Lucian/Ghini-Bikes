using Ghini_Bikes.Exceptions;
using Ghini_Bikes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghini_Bikes.Users
{
    public class NormalUser : User
    {
        private string img;
        private string[] vouchers;
        private List<Product> cart = new List<Product>();

        public NormalUser(string name, string password, string email,string img) : base(name, password, email)
        {
            this.img = img;
        }

        public void Place_Order()
        {
            if (cart == null)
                throw new EmptyCartException(" Cart is empty!");
            else
            {
                Console.WriteLine("Order contain:");
                foreach (Product product in cart)
                    Console.WriteLine($"  {product.ToString()}");
            }
        }

        public  void AddToCart(Product p)
        {
            if (p != null)
                cart.Add(p);
            else throw new ArgumentNullException("invalid product");
        }

        public  double GetTotalPrice()
        {
            if (cart.Any() == false)
            {
                EmptyCartException ex =new EmptyCartException("Cart is empty!");
                throw ex;
                   
            }
            
            double s = 0.0;
            foreach(Product p in cart)
            {
                s += p.Price;
            }
            return s;
        }

        
    }
}
