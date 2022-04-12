using Application;
using Domain.Bikes;
using Domain.Models;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AccessoryRepository : IAccessoryRepository
    {
        private readonly ShopDbContext _db;

        public AccessoryRepository(ShopDbContext db) { _db = db; }
        public void CreateAccessory(Accessory accessory)
        {
            if (accessory == null)
                throw new ArgumentNullException();
            accessory.Category = 5;
            _db.Add(accessory);
        }

        public void DeleteAccessory(Accessory accessory)
        {
            try
            {
                var accessoryRemove = _db.Products.Single(acc => acc.Manufacturer == accessory.Manufacturer && acc.Model == accessory.Model && acc.Year == accessory.Year);
                _db.Products.Remove(accessoryRemove);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public IEnumerable<Product> GetAccessories()
        {
            return _db.Products.Where( p => p.Category == 5 );
        }

        public Product GetAccessoryById(int accessoryId)
        {
            return _db.Products.FirstOrDefault(acc => acc.ProductId == accessoryId);
        }

        public void UpdateAccessory(int accessoryId, Accessory accessory)
        {
            int ok = 0;
            if (accessoryId < 0) throw new ArgumentOutOfRangeException("Invalid accessory ID");
            foreach (Accessory acc in _db.Products)
                if (acc.ProductId == accessoryId)
                {
                    ok = ok + 1;
                    acc.Price = accessory.Price;
                    acc.Manufacturer = accessory.Manufacturer;
                    acc.Model = accessory.Model;
                    acc.Year = accessory.Year;
                    acc.Description = accessory.Description;
                    break;
                }
            if (ok == 0) throw new InvalidOperationException("Invalid accessory ID");
        }
    }
}
