using Application;
using Domain.Models;
using Domain.Products;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class PartRepository : IPartRepository
    {
        private readonly ShopDbContext _db;

        public PartRepository(ShopDbContext db) { _db = db; }

        public void CreatePart(Part part)
        {
            if (part == null) throw new ArgumentNullException("Part parameter null!");
            part.Category = 4;
            _db.Products.Add(part);

        }

        public void DeletePart(Part part)
        {
            try
            {
                var partRemove = _db.Products.Single(p => p.Manufacturer == part.Manufacturer && p.Model == part.Model && part.Year == p.Year);
                _db.Products.Remove(partRemove);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Product GetPartById(int partId)
        {
            if (partId < 0) throw new ArgumentOutOfRangeException("Incorrect part Id");
            return _db.Products.FirstOrDefault(p => p.ProductId == partId);
        }

        public IEnumerable<Product> GetParts()
        {
            return _db.Products.Where(p => p.Category == 4);
        }

        public void UpdatePart(int partId, Part part)
        {
            int ok = 0;
            foreach (Part p in _db.Products)
                if (p.ProductId == partId)
                {
                    ok = ok + 1;
                    p.Manufacturer = part.Manufacturer;
                    p.Model = part.Model;
                    p.Year = part.Year;
                    p.Description = part.Description;
                    p.Price = part.Price;
                    break;
                }
            if (ok == 0) throw new InvalidOperationException("Invalid part Id");
        }
    }
}
