using Application;
using Domain.Models;
using Domain.Products;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
            _db.SaveChanges();

        }

        public Part DeletePart(int partId)
        {
            try
            {
                var partRemove = _db.Products.Single(p => p.ProductId == partId);
                _db.Products.Remove(partRemove);
                _db.SaveChanges();
                return (Part)partRemove;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public Part GetPartById(int partId)
        {
            if (partId < 0) throw new ArgumentOutOfRangeException("Incorrect part Id");
            return _db.Parts.FirstOrDefault(p => p.ProductId == partId);
        }

        public IEnumerable<Part> GetParts()
        {
            return _db.Parts.Include(p =>p.Images).Include(p1 => p1.Compatibilities);
        }

        public void UpdatePart(int partId, Part part)
        {
            int ok = 0;
            foreach (Part p in _db.Parts)
                if (p.ProductId == partId)
                {
                    ok = ok + 1;
                    p.Manufacturer = part.Manufacturer;
                    p.Model = part.Model;
                    p.Year = part.Year;
                    p.Description = part.Description;
                    p.Price = part.Price;
                    p.Quantity = part.Quantity;
                    p.Compatibilities = part.Compatibilities;
                    break;
                }
            if (ok == 0) throw new InvalidOperationException("Invalid part Id");
            _db.SaveChanges();
        }
    }
}
