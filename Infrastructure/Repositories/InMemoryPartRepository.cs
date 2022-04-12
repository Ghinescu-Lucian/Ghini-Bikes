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
    public class InMemoryPartRepository : IPartRepository
    {
        private readonly List<Part> _parts = new();

        public void CreatePart(Part part)
        {
            if(part == null) throw new ArgumentNullException("Part parameter null!");
            part.ProductId = _parts.Count + 1;
            _parts.Add(part);

        }

        public void DeletePart(Part part)
        {
            try
            {
                var partRemove = _parts.Single(p => p.Manufacturer == part.Manufacturer && p.Model == part.Model && part.Year == p.Year);
                _parts.Remove(partRemove);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Product GetPartById(int partId)
        {
            if (partId < 0) throw new ArgumentOutOfRangeException("Incorrect part Id");
            return _parts.FirstOrDefault(p => p.ProductId == partId);
        }

        public IEnumerable<Product> GetParts()
        {
           return _parts;
        }

        public void UpdatePart(int partId, Part part)
        {
            int ok = 0;
            foreach (Part p in _parts)
                if (p.ProductId == partId)
                {
                    ok = ok + 1;
                    p.Manufacturer = part.Manufacturer;
                    p.Model = part.Model;
                    p.Year = part.Year;
                    p.Description = part.Description;
                    p.Price=part.Price;
                    break;
                }
            if (ok == 0) throw new InvalidOperationException("Invalid part Id");
        }
    }
}
