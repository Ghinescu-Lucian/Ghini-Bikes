using System;

namespace Ghini_Bikes.Bikes
{

	/// <summary>
	/// Summary description for Class1
	/// </summary>
	public class Bike:Product
	{
		private static int lastId = 0;
		private readonly int id;
		
		private int year;
		private string specs;

		public int Year { get { return year; } set { year = value; } }
		public string Specification { get { return specs; } set { specs = value; } }

		public Bike(string man, string model, int year , string specs,double price)
		{
			Manufacturer = man;
			Model	 = model;
			Year = year;
			Specification = specs;
			Price = price;
			id= lastId++;
		}

		public override string ToString()
        {
			string s = "Normal bike!";
			return s;
        }
		public double Coeficient()
        {
			double coef = Price/this.year;
			return coef;

        }
	}
}
