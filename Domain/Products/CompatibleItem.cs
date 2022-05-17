using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CompatibleItem
    {
        public int Id { get; set; }

        public int Bike_Id { get; set; }
        public Product Bike { get; set; }

    }
}
