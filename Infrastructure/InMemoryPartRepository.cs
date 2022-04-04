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

        public void DeletePart(Part part)
        {
            throw new NotImplementedException();
        }

        public Part GetPartById(int partId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Part> GetParts()
        {
            throw new NotImplementedException();
        }

        public void UpdatePart(int partId, Part part)
        {
            throw new NotImplementedException();
        }
    }
}
