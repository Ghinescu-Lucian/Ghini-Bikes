using Ghini_Bikes.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghini_Bikes.Products
{
    public class MTBBike : Bike,ICloneable
    {
        private string suspension;
        public MTBBike(string man, string model,int year, string specs,double price, string suspension) : base(man, model, year, specs,price)
        {
            this.suspension = suspension;
        }
        /*public override string ToString()
        {
            string s = base.ToString();
            s = s + ", but i love going off-road!";
            return s;
        }*/
        public double Coeficient(int reviews)
        {
            double coef = base.Coeficient();
            coef += reviews;
            return reviews;
        }

        public object Clone()
        {
            return new MTBBike(this.Manufacturer, this.Model, this.Year, this.Specification, this.Price, this.suspension);
        }
    }

   
}
