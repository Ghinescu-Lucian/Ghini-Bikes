using Ghini_Bikes.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghini_Bikes.Products
{
    public class PromoPackage :Product, IEnumerable<Product>
    {
        private List<Product> package = new List<Product>();

        public void AddProduct(Product p)
        {
            package.Add(p);
        }

        public int GetNo()
        {
            return package.Count;
        }

        public List<Product> GetPackage()
        {
            return this.package;
        }

        public override string ToString()
        {
            string s = "Promo - Package : ";
            for(int i = 0; i < package.Count; i++)
            {
                s+="\n    "+package[i].ToString();
            }
            return s;
        }
      

        public IEnumerator<Product> GetEnumerator()
        {
            return new ProductEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class ProductEnumerator : IEnumerator<Product>
    {
        private PromoPackage promoPackage;
        private int index;

        public ProductEnumerator(PromoPackage promoPackage)
        {
            this.promoPackage = promoPackage;
            index = -1;
        }

        public Product Current => promoPackage.GetPackage()[index];

        object IEnumerator.Current => Current;

        public void Dispose()   
        {
        }

        public bool MoveNext()
        {
            index++;
            return index < promoPackage.GetNo();
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
