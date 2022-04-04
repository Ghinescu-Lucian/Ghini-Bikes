using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProductFactory
{
    public interface IProductFactory<T>
    {
       public T CreateProduct(int year, double price, string model, string manufacturer, string description);
    }
}
