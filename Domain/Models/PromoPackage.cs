using Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PromoPackage : IEnumerable<PromoItem>
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }   
        public List<PromoItem> Items { get; set; }


        public void AddProduct(Product p,int quantity, double discount)
        {
          /*  PromoItem item = new PromoItem { Discount = discount, Quantity = quantity, Price = p.Price, Image = p.Image };
            Items.Add(item);
          */
        }

        public int GetNo()
        {
            return Items.Count;
        }

        public List<PromoItem> GetPackage()
        {
            return this.Items;
        }

        public override string ToString()
        {
            string s = "Promo - Package : ";
            for(int i = 0; i < Items.Count; i++)
            {
                s+="\n    "+Items[i].ToString();
            }
            return s;
        }
      

        public IEnumerator<PromoItem> GetEnumerator()
        {
            return new PromoItemEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class PromoItemEnumerator : IEnumerator<PromoItem>
    {
        private PromoPackage promoPackage;
        private int index;

        public PromoItemEnumerator(PromoPackage promoPackage)
        {
            this.promoPackage = promoPackage;
            index = -1;
        }

        public PromoItem Current => promoPackage.GetPackage()[index];

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
