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
        void DeleteAccessory(Accessory accessory);
        Accessory GetAccessoryById(int accessoryId);
        void UpdateAccessory(int accessoryId, Accessory accessory);
    }
}
