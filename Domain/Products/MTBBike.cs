using Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products
{
    public class MTBBike : Bike,ICloneable
    {
        public string Suspension { get; set; }
       /* public MTBBike(string man, string model,int year, string specs,double price, string suspension) : base(man, model, year, specs,price)
        {
            this.suspension = suspension;
        }*/
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
            return new MTBBike{
                Manufacturer = this.Manufacturer, 
                Model = this.Model, 
                Year = this.Year, 
                Specification = this.Specification, 
                Price = this.Price, 
                Suspension = this.Suspension 
            };
        }
    }

   
}
