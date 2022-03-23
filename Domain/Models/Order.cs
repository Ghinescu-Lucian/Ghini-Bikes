using Domain.Collections;
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
        private static int initialid = 0;
        private Collection<Product> Products { get; set; }
        private DateTime DateTime { get; set; }
        private float TotalCost { get; set; }
        private User User { get; set; }
        private string NrTelephone { get; set; }
        private string Address { get; set; }

        private Payment? Pay { get; set; }

        private Status? Status { get; set; }

        public Order(Collection<Product> items, float totalCost, User user)
        {
            DateTime d = DateTime.Now;
            Products = items;
            DateTime = d;
            TotalCost = totalCost;
            User = user;
        }
    }
}
