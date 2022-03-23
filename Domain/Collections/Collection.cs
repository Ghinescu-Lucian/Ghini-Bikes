using Domain.Models;
using Domain.Products;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Domain.Collections
{
    public class Collection<T> : IEqualityComparer<T> where T : Product
    {
        private T[] array;
        private int index;
        private int? minSize;
        private HashSet<T> set;
        

        public Collection()
        {
            array = new T[100];
            set = new HashSet<T>();
            index = 0;
        }

        public void AddItem(T item)
        {
            if (index < 100)
            {
                array[index++] = item;
                set.Add(item);
            }

        }

        // remove the last record 
        public T RemoveItem()
        {
            index--;
            if(index >= 0)
            {
                T aux = array[index]; ;
                array[index] = null;
                return aux;
            }
            else return null;
        }

        public T GetItem(int index)
        {
            if(minSize.HasValue)
            {
                if (index < 100 && index > minSize.Value) ;
                    return null;
                return array[index];
            }
            else
                 return array[index];   
        }

        public T[] GetAll()
        {
            return array;
        }

        public T[] GetHashSet()
        {
            if (set == null)
                return null;
            return set.ToArray();
        }

        public void SetItem(int index, T value)
        {
            if (index < 100)
                array[index] = value; 
        }
        public  void SwapItems(int index1, int index2)
        {
            T swap;
            swap = array[index1];
            array[index1] = array[index2];
            array[index2] = swap;
        }

        public bool Equals(T? x, T? y)
        {
            if (x.Manufacturer.Equals(y.Manufacturer) && x.Model.Equals(y.Model) && x.Year == y.Year)
                return true;
            return false;
        }

        public int GetHashCode([DisallowNull] T obj)
        {
            return (obj.Manufacturer + ";" + obj.Model + ";" + obj.Year).GetHashCode();
        }
    }
}
