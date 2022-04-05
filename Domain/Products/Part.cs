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
        private List<Bike> _compatibilities;

        public Part()
        {
            _compatibilities = new List<Bike>();
        }
        public void AddCompatibleBike(Bike bike)
        {
            if (bike == null) throw new ArgumentNullException("Bike parameter is null");
            _compatibilities.Add(bike);
        }

        public void RemoveCompatibleBike(Bike bike)
        {
            if(bike == null) throw new ArgumentNullException("Bike parameter is null");
            var bikeRemove = _compatibilities.Single(b => b.productId == bike.productId);
            _compatibilities.Remove(bikeRemove);
        }
        public IEnumerable<Bike> Compatibilities()
        {
            return _compatibilities;
        }
    }
}
