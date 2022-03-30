using Application;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class InMemoryPartRepository : IPartRepository
    {
        public void CreatePart(Part part)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Part> GetParts()
        {
            throw new NotImplementedException();
        }
    }
}
