using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        IEnumerable<Order> GetOrders();
        void DeleteOrder(Order order);
        User GetOrderById(int orderId);
        void UpdateOrder(int orderId, Order order);
    }
}
