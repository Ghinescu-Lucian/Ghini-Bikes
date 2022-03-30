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
    }
}
