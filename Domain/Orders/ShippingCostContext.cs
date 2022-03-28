using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders
{
    public class ShippingCostContext
    {
        private IShippingCostStrategy _strategy;

        public void SetStrategy(IShippingCostStrategy strategy)
        {
            _strategy = strategy;
        }
        public double CalculateShippingCost()
        {
            return _strategy.CalculateShippingCost();
        }

        public override string ToString()
        {
            string s = _strategy.CalculateShippingCost().ToString();
            return s;
        }
    }
}
