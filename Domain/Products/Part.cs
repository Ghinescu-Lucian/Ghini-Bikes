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
        public List<CompatibleItem> Compatibilities { get; set; }

        public Part()
        {
            Compatibilities = new List<CompatibleItem>();
        }
        public void AddCompatibleBike(CompatibleItem bike)
        {
            if (bike == null) throw new ArgumentNullException("Bike parameter is null");
            Compatibilities.Add(bike);
        }

        public void RemoveCompatibleBike(CompatibleItem bike)
        {
            if(bike == null) throw new ArgumentNullException("Bike parameter is null");
            var bikeRemove = Compatibilities.Single(b => b.Id == bike.Id);
            Compatibilities.Remove(bikeRemove);
        }
       
    }
}
