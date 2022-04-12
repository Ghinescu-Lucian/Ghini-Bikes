using Application;
using Domain.Models;
using Domain.Products;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BikeRepository:IBikeRepository
    {
        private readonly ShopDbContext _db;
        public BikeRepository(ShopDbContext db) { _db = db; }
        public void CreateBike(Bike bike)
        {
            if (bike == null)
                throw new ArgumentNullException();
            _db.Products.Add(bike);
            _db.SaveChanges();
        }

        public void DeleteBike(Bike bike)
        {
            try
            {
                var bikeRemove = _db.Products.Single(b => b.Manufacturer == bike.Manufacturer && b.Model == b.Model && b.Year == b.Year);
                _db.Products.Remove(bikeRemove);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            _db.SaveChanges();
        }

        public Product GetBikeById(int bikeId)
        {
            return _db.Products.FirstOrDefault(acc => acc.ProductId == bikeId);
        }

        public IEnumerable<Product> GetBikes()
        {
            return _db.Products.Where(p => p.Category == (int)2 );
        }



        public void UpdateBike(int bikeId, Bike bike)
        {
            int ok = 0;
            if (bikeId < 0) throw new ArgumentOutOfRangeException("Invalid accessory ID");
            foreach (Bike acc in _db.Products)
                if (acc.ProductId == bikeId)
                {
                    ok = ok + 1;
                    acc.Price = bike.Price;
                    acc.Manufacturer = bike.Manufacturer;
                    acc.Model = bike.Model;
                    acc.Year = bike.Year;
                    acc.Description = bike.Description;
                    acc.Category = bike.Category;
                    break;
                }
            if (ok == 0) throw new InvalidOperationException("Invalid accessory ID");
            _db.SaveChanges();
        }
    }
}
