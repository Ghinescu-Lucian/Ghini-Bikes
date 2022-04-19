using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly ShopDbContext _db;

        public PromotionRepository(ShopDbContext db) { _db = db; }
        public void CreatePromotion(PromoPackage package)
        {
            _db.Add(package);
            _db.SaveChanges();
        }

        public PromoPackage DeletePromotion(int packageId)
        {
            var packageDelete = GetPromotionById(packageId);
            if (packageDelete == null) return null;
            _db.Promotions.Remove(packageDelete);
            _db.SaveChanges();
            return packageDelete;

        }

        public PromoPackage GetPromotionById(int packageId)
        {
            var promotions = _db.Promotions.Include(i => i.Items).SingleOrDefault(pack => pack.Id == packageId);
            return promotions;
        }

        public IEnumerable<PromoPackage> GetPromotions()
        {
            var promotions = _db.Promotions.Include(i => i.Items);
            return promotions;
        }

        public void UpdatePromotion(int packageId, PromoPackage package)
        {
            var packageUpdate = GetPromotionById(packageId);
            packageUpdate.Name = package.Name;
            packageUpdate.Items = package.Items;
            //  _db.Users.Remove(userUpdate);
            _db.SaveChanges();
        }

    }
}
