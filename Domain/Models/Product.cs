using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Product
    {
        
        public int ProductId { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        public int Year { get; set; }
        public double Price { get; set; }
        [Required, MaxLength(30)]
        public string Manufacturer { get; set; }
        [Required, MaxLength(30)]
        public string Model { get; set; }
        [Required]
        public List<Image> Images { get; set; }
        public int Quantity { get; set; }
        [Required]
        public int Category { get; set; }

        public override string ToString()
        {
            string s = Manufacturer + " " + Model + " " + Price + " "+Description;
            return s;
        }
    }
}
