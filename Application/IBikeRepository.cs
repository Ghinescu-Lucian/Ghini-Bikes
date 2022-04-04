using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IBikeRepository
    {
        void CreateBike(Bike bike);
        IEnumerable<Bike> GetBikes();
        void DeleteBike(Bike bike);
        Bike GetBikeById(int bikeId);
        void UpdateBike(int bikeId, Bike bike);
    }
}
