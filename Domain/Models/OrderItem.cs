using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class OrderItem
    {
        
        public int Id { get; set; }
        public int ProductId { get; set; }
      
        public string Description { get; set; }
        
        public int Year { get; set; }
        public double Price { get; set; }
 
        public string Manufacturer { get; set; }
        
        public string Model { get; set; }
      
        public string Image { get; set; }
        
        public int Category { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
        public double Discount { get; set; }
        public int Quantity { get; set; }
        
    }
}
