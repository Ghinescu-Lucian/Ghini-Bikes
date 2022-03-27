using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products
{
    public abstract class BaseBikeDecorator : IBike
    {
        protected IBike _bike;

        public BaseBikeDecorator(IBike bike)
        {
            _bike = bike;
        }

        public abstract double GetPrice();

        public abstract int GetWarrantyMonths();
       
    }
}
