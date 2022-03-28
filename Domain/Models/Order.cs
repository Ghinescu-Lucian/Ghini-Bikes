using Domain.Bikes;
using Domain.Collections;
using Domain.Orders;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Status : byte { Accepted = 1, Rejected, Pending };
 public enum Payment : byte { Cash, Card };

namespace Domain.Models
{
    public class Order
    {
        private static int initialId = 0;
        private List<Product> Products { get; set; }

        private int Id;
        public DateTime DateTime { get; set; }
        public double TotalCost { get; set; }

        public double FinalCost { get; set; }
        private User User { get; set; }
        public string NrTelephone { get; set; }
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


            DateTime  = DateTime.Now;
            Products = items;
            TotalCost = totalCost;
            User = user;
            Id = initialId++;
        }
        public override string ToString()
        {
            string s = " Comanda cu id: " + Id + " are costul "+FinalCost+"lei (livrare = "+(FinalCost-TotalCost) + " lei )";
            return s;
        }
    }
}
