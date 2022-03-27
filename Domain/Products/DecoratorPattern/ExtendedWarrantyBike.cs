using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products
{
    public class ExtendedWarrantyBike : BaseBikeDecorator
    {
        public int ExtraWarrantyMonths { get; set; }
        public int ExtraPrice { get; set; }
        public ExtendedWarrantyBike(IBike bike) : base(bike) { }
       

        public override double GetPrice()
        {
            return _bike.GetPrice() + ExtraPrice;
        }

        public override int GetWarrantyMonths()
        {
           return _bike.GetWarrantyMonths() + ExtraWarrantyMonths;
        }

       
    }
}
