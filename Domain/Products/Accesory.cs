using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Bikes
{
    public class Accesory : Product
    {
       
        public override string ToString()
        {
            string s = Manufacturer + " " + Model + " " + Price;
            return s;
        }
    }
}
