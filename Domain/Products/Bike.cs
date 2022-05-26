using Domain.Models;

namespace Domain.Products
{

	public class Bike:Product,IBike
	{
		private static int lastId = 0;
		private readonly int id;
		
		//public int Year;

		public int WarrantyMonths { get; set; }
		public string Specification { get; set; }
		public double Weight { get; set; }

		public Bike()
		{
			id= lastId++;
		}

		public override string ToString()
        {
			string s = Manufacturer + " "+ Model + " "+Year;
			return s;
        }
		public double Coeficient()
        {
			double coef = Price/Year;
			coef= Math.Round(coef, 2);
			return coef;

        }

        public double GetPrice()
        {
			return Price;
        }

        public int GetWarrantyMonths()
        {
            return WarrantyMonths;
        }
    }
}
