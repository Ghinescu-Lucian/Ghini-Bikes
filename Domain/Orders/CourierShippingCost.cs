using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Orders
{
    public class CourierShippingCost: IShippingCostStrategy
    {
        public double OrderPrice { get; set; }
       

        public double CalculateShippingCost()
        { 
            
            if (OrderPrice > 500)
                return 0;
           
            else
                return 25.0;

           // return 0;
        }

    }
}
