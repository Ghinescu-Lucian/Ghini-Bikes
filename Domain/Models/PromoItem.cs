using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PromoItem
    {
        public int Id { get; set; }
        public double Discount { get; set; }
        public Product _Product { get; set; }
        public int Quantity { get; set; }


    }
}
