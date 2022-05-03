using Domain.Models;
using Domain.Products;

namespace Application
{
    public interface IBikeRepository 
    {
        void CreateBike(Bike bike);
        IEnumerable<Product> GetBikes();
        Product GetBikeById2(int bikeId);
        Bike DeleteBike(int bikeId);
        Bike GetBikeById(int bikeId);
        IEnumerable<Bike> GetAllBikes();
        void UpdateBike(int bikeId, Bike bike);
    }
}
