using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
   public interface IUserRepository
    {
        void CreateUser(User user);
        IEnumerable<User> GetUsers();
        User DeleteUser(int userId);
        User GetUserById(int userId);
        void UpdateUser(int userId,User user);
    }
}
