using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IPromotionRepository 
    {
        void CreatePromotion(PromoPackage package);
        IEnumerable<PromoPackage> GetPromotions();
        PromoPackage DeletePromotion(int packageId);
        PromoPackage GetPromotionById(int packageId);
        void UpdatePromotion(int packageId, PromoPackage package);
    }
}
