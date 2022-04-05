using Domain.Bikes;
using Domain.Collections;
using Domain.Enums;
using Domain.Orders;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Domain.Models
{
    public class Order
    {
        private List<Product> Products { get; set; }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double TotalCost { get; set; }

        public double FinalCost { get; set; }
        public User User { get; set; }
        public string TelephoneNr { get; set; }
        public string Address { get; set; }

        public Payment? Pay { get; set; }

        public Status? Status { get; set; }

        public ShippingCostContext ShippingCost { get; set; }

        public Order(List<Product> items, User user, string shippingMethod)
        {
            double totalCost = 0;

            foreach (Product product in items)
                totalCost += product.Price;
            ShippingCost = new ShippingCostContext();
            if (string.Equals(shippingMethod, "Personal"))
            {
                ShippingCost.SetStrategy(new PesonalLiftShippingCost()); 
            }

            else if (string.Equals(shippingMethod, "Courier"))
            {
                ShippingCost.SetStrategy(new CourierShippingCost() { OrderPrice = totalCost });
            }
            else throw new Exception("Invalid shipping method");

            FinalCost =totalCost + ShippingCost.CalculateShippingCost();


            Date  = DateTime.Now;
            Products = items;
            TotalCost = totalCost;
            User = user;
        }
        public override string ToString()
        {
            string s = " Comanda cu id: " + Id + " are costul "+FinalCost+"lei (livrare = "+(FinalCost-TotalCost) + " lei )";
            return s;
        }
    }
}
