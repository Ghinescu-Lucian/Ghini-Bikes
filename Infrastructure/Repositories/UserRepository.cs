using Application;
using Domain.Models;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ShopDbContext _db;

        public UserRepository (ShopDbContext db) { _db = db; }
        public void CreateUser(User user)
        {
            _db.Add(user);
            _db.SaveChanges();
        }

        public User DeleteUser(int userId)
        {
            var userDelete = GetUserById(userId);
            if (userDelete == null) return null;
            _db.Users.Remove(userDelete);
            _db.SaveChanges();
            return userDelete;
         
        }

        public User GetUserById(int UserId)
        {
            var user=  _db.Users.SingleOrDefault(u => u.Id == UserId);
            return user;
        }
        public User GetUserByUsername(string Username)
        {
            var user = _db.Users.SingleOrDefault(u => u.Username == Username);
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            var users = _db.Users.ToList();
            return users;
        }

        public void UpdateUser(int userId, User user)
        {
            var userUpdate = GetUserById(userId);
            userUpdate.Username=user.Username;
            userUpdate.Password=user.Password;  
            userUpdate.Email=user.Email;
            userUpdate.Orders=user.Orders;
          //  _db.Users.Remove(userUpdate);
            _db.SaveChanges();
        }

       
    }
}
