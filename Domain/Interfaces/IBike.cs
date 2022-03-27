using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products
{
    public interface IBike
    {
        public abstract double GetPrice();
        public abstract int GetWarrantyMonths();

    }
}
