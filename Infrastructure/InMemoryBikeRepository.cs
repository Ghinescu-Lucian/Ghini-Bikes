using Application;
using Domain.Models;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class InMemoryBikeRepository : IBikeRepository
    {
        public void CreateBike(Bike bike)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bike> GetBikes()
        {
            throw new NotImplementedException();
        }
    }
}
