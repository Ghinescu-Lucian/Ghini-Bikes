using Application;
using Domain.Models;
using Domain.Products;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShopDbContext _db;
        public OrderRepository(ShopDbContext db) { _db = db; }
        public void CreateOrder(Order order)
        {
            if (order == null) throw new ArgumentNullException("order parameter is null");
            //Console.WriteLine("AIci");
            _db.Users.SingleOrDefault(u => u.Id == order.UserId).Orders.Add(order);
            //_db.Add(order);
            _db.SaveChanges();
        }

        public Order DeleteOrder(int orderId)
        {
            if (orderId < 0) throw new ArgumentOutOfRangeException(" Invalid order id " + orderId);
            var orderDelete = _db.Orders.Include(o => o.Items).Single(o => o.Id == orderId);
            foreach (OrderItem oi in orderDelete.Items)
                _db.Remove(oi);
            _db.Remove(orderDelete);
            _db.SaveChanges();
            return orderDelete;

        }

        public IEnumerable<Order> GetAllOrders()
        {
            var orders = _db.Orders.Include( x => x.Items);
            foreach(Order o in orders)
            {
                foreach (OrderItem oi in o.Items)
                {
                    oi.Order = null;
                   
                }
            }
            return orders;
        }

        public Order GetOrderById(int orderId)
        {
            if (orderId < 0) throw new ArgumentOutOfRangeException(" Invalid order id " + orderId);
            var order = _db.Orders.Include(i => i.Items).SingleOrDefault(i => i.Id == orderId);
            foreach (OrderItem oi in order.Items)
            {
                oi.Order = null;
            }
            return order;
        }

        public IEnumerable<Order> GetOrdersByUser(int userId)
        {
            if (userId == null || userId <= 0) throw new ArgumentNullException("user parameter is null");
            var result = _db.Orders.Where(o => o.UserId == userId);
            return result;
        }

        public void UpdateOrder(int orderId, Order order)
        {
            if (orderId < 0) throw new ArgumentOutOfRangeException("Invalid order Id ( <0 )" + orderId);
            if (order == null) throw new ArgumentNullException("order parameter is null");
            int ok = 0;
            foreach (Order o in _db.Orders.Include(oi => oi.Items))
                if (o.Id == orderId)
                {
                    ok = ok + 1;
                    var initialStatus = o.Status;
                    o.Status = order.Status;
                    o.Message = order.Message;
                    if(o.Status == Domain.Enums.Status.Accepted && initialStatus!= Domain.Enums.Status.Accepted)
                    {
                        for( var i = 0; i < o.Items.Count; i++)
                        {
                            if(o.Items[i].Category <= 3)
                            {
                               Bike bike = _db.Bikes.First(b => b.ProductId == o.Items[i].ProductId);
                                bike.Quantity = bike.Quantity - o.Items[i].Quantity;
                            }
                            if (o.Items[i].Category == 4)
                            {
                                Part part = _db.Parts.First(b => b.ProductId == o.Items[i].ProductId);
                                part.Quantity = part.Quantity - o.Items[i].Quantity;
                            }
                            if (o.Items[i].Category == 5)
                            {
                                Accessory acc = _db.Accessories.First(b => b.ProductId == o.Items[i].ProductId);
                                acc.Quantity = acc.Quantity - o.Items[i].Quantity;
                            }

                        }
                    }
                    if (o.Status != Domain.Enums.Status.Accepted && initialStatus == Domain.Enums.Status.Accepted)
                    {
                        for (var i = 0; i < o.Items.Count; i++)
                        {
                            if (o.Items[i].Category <= 3)
                            {
                                Bike bike = _db.Bikes.First(b => b.ProductId == o.Items[i].ProductId);
                                bike.Quantity = bike.Quantity + o.Items[i].Quantity;
                            }
                            if (o.Items[i].Category == 4)
                            {
                                Part part = _db.Parts.First(b => b.ProductId == o.Items[i].ProductId);
                                part.Quantity = part.Quantity + o.Items[i].Quantity;
                            }
                            if (o.Items[i].Category == 5)
                            {
                                Accessory acc = _db.Accessories.First(b => b.ProductId == o.Items[i].ProductId);
                                acc.Quantity = acc.Quantity + o.Items[i].Quantity;
                            }

                        }
                    }
                    break;
                }
            if (ok == 0) throw new InvalidOperationException("Invalid order Id");
            _db.SaveChanges();
        }
    }
}
