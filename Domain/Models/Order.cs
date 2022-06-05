using Domain.Bikes;
using Domain.Collections;
using Domain.Enums;
using Domain.Orders;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> Items { get; set; }

        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double TotalCost { get; set; }
        [Required]
        public double FinalCost { get; set; }
        public int UserId { get; set; }

        [Required, MaxLength(13)]
        public string TelephoneNr { get; set; }
        [Required, MaxLength(50)]
        public string Address { get; set; }

        public Payment? Pay { get; set; }

        public Status? Status { get; set; }

        public ShippingCostContext ShippingCost;

        public string Name { get; set; }
        public string? Message { get; set; }

        /* public Order(List<OrderItem> Items, User User, string shippingMethod)
         {
             double totalCost = 0;

             foreach (OrderItem product in Items)
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
             OrderItems = Items;
             TotalCost = totalCost;
             User = User;
         }*/

        public override string ToString()
        {
            string s = " Comanda cu id: " + Id + " are costul " + FinalCost + "lei (livrare = " + (FinalCost - TotalCost) + " lei )";
            return s;
        }
    }
}
