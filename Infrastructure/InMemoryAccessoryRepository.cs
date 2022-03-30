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
        public void CreateAccessory(Accessory accessory)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Accessory> GetAccessories()
        {
            throw new NotImplementedException();
        }
    }
}
