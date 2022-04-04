using Domain.Models;

namespace Domain.Products
{

	public class Bike:Product,IBike
	{
		private static int lastId = 0;
		private readonly int id;
		
		private int year;

		public int WarrantyMonths { get; set; }
		public string Specification { get; set; }

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
			double coef = Price/this.year;
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
