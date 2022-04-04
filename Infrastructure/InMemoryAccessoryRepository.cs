using Application;
using Domain.Bikes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class InMemoryAccessoryRepository : IAccessoryRepository
    {
        private readonly List<Accessory> _accessories = new();
        public void CreateAccessory(Accessory accessory)
        {
            if (accessory == null)
                throw new ArgumentNullException();
            accessory.productId = _accessories.Count;
            _accessories.Add(accessory);
        }

        public void DeleteAccessory(Accessory accessory)
        {
            try
            {
                var accessoryRemove = _accessories.Single(acc => acc.Manufacturer == accessory.Manufacturer && acc.Model == accessory.Model && acc.Year == accessory.Year);
                _accessories.Remove(accessoryRemove);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public IEnumerable<Accessory> GetAccessories()
        {
            return _accessories;
        }

        public Accessory GetAccessoryById(int accessoryId)
        {
            return _accessories.FirstOrDefault(acc => acc.productId == accessoryId);
        }

        public void UpdateAccessory(int accessoryId, Accessory accessory)
        {
            int ok = 0;
            if(accessoryId < 0) throw new ArgumentOutOfRangeException("Invalid accessory ID");
            foreach (Accessory acc in _accessories)
                if (acc.productId == accessoryId)
                {
                    ok = ok + 1;
                    acc.Price = accessory.Price;
                    acc.Manufacturer=accessory.Manufacturer;
                    acc.Model=accessory.Model;
                    acc.Year=accessory.Year;
                    acc.Description=accessory.Description;
                    break;
                }
            if (ok == 0) throw new InvalidOperationException("Invalid accessory ID");
        }
    }
}
