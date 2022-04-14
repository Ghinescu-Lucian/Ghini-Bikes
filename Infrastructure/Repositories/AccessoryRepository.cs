using Application;
using Domain.Models;
using Domain.Products;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
            _db.SaveChanges();
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
            _db.SaveChanges();  
        }

        public IEnumerable<Accessory> GetAccessories()
        {
            return _db.Accessories.Include( a => a.Images);
        }

        public Accessory GetAccessoryById(int accessoryId)
        {
            return _db.Accessories.FirstOrDefault(acc => acc.ProductId == accessoryId);
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
            _db.SaveChanges();
        }
    }
}
