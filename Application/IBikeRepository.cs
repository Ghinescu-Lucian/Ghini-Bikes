using Domain.Models;
using Domain.Products;

namespace Application
{
    public interface IBikeRepository 
    {
        void CreateBike(Bike bike);
        IEnumerable<Product> GetBikes();
        void DeleteBike(Bike bike);
        Bike GetBikeById(int bikeId);
        IEnumerable<Bike> GetAllBikes();
        void UpdateBike(int bikeId, Bike bike);
    }
}
