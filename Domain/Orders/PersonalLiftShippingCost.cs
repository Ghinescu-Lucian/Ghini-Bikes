using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders
{
    public class PesonalLiftShippingCost : IShippingCostStrategy
    {
        public double CalculateShippingCost()
        {
            return 0.0;
        }
    }
}
