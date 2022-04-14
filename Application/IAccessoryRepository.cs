using Domain.Models;
using Domain.Products;

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
