using Domain.Bikes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IAccessoryRepository
    {
        void CreateAccessory(Accessory accessory);
        IEnumerable<Accessory> GetAccessories();
    }
}
