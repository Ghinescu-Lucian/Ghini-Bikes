using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products
{
    public class Part : Product
    {
        public List<Bike> Compatibilities { get; set; }

        public Part()
        {
            Compatibilities = new List<Bike>();
        }
        public void AddCompatibleBike(Bike bike)
        {
            if (bike == null) throw new ArgumentNullException("Bike parameter is null");
            Compatibilities.Add(bike);
        }

        public void RemoveCompatibleBike(Bike bike)
        {
            if(bike == null) throw new ArgumentNullException("Bike parameter is null");
            var bikeRemove = Compatibilities.Single(b => b.ProductId == bike.ProductId);
            Compatibilities.Remove(bikeRemove);
        }
       
    }
}
