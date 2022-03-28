using Domain.Collections;
using Domain.Exceptions;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public class NormalUser : User
    {
        private string img;
        private string[] vouchers;
        private List<Product> cart = new List<Product>();
        private List<Order>? orders;

        public NormalUser(string name, string password, string email,string img) : base(name, password, email)
        {
            this.img = img;
        }

        public Order Place_Order(string shippingMethod)
        {
            if (cart == null)
                throw new EmptyCartException(" Cart is empty!");
            else
            {
                Order  order = new Order(cart,this,shippingMethod);
                cart.Clear();
                return order;
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
        public List<Order> GetOrder()
        {
            if(orders != null)
                return orders;
            return null;
        }

        
    }
}
