using Application;
using Domain.Bikes;
using Domain.Models;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class InMemoryBikeRepository : IBikeRepository
    {
        private readonly List<Bike> _bikes = new();
        public void CreateBike(Bike bike)
        {
            if (bike == null)
                throw new ArgumentNullException();
            bike.productId = _bikes.Count;
            _bikes.Add(bike);
        }

        public void DeleteBike(Bike bike)
        {
            try
            {
                var bikeRemove = _bikes.Single(b => b.Manufacturer == bike.Manufacturer && b.Model == b.Model && b.Year == b.Year);
                _bikes.Remove(bikeRemove);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Bike GetBikeById(int bikeId)
        {
            return _bikes.FirstOrDefault(acc => acc.productId == bikeId);
        }

        public IEnumerable<Bike> GetBikes()
        {
            return _bikes;
        }

     

        public void UpdateBike(int bikeId, Bike bike)
        {
            int ok = 0;
            if (bikeId < 0) throw new ArgumentOutOfRangeException("Invalid accessory ID");
            foreach (Bike acc in _bikes)
                if (acc.productId == bikeId)
                {
                    ok = ok + 1;
                    acc.Price = bike.Price;
                    acc.Manufacturer = bike.Manufacturer;
                    acc.Model = bike.Model;
                    acc.Year = bike.Year;
                    acc.Description = bike.Description;
                    break;
                }
            if (ok == 0) throw new InvalidOperationException("Invalid accessory ID");
        }
    }
}
