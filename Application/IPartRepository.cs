using Domain.Models;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IPartRepository 
    {
        void CreatePart(Part part);
        IEnumerable<Part> GetParts();
        Part DeletePart(int partId);
        Part GetPartById(int partId);
        void UpdatePart(int partId,Part part);
    }
}
