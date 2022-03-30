
using Application;
using Domain.Models;

namespace Infrastructure
{
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> _users = new();
        public void CreateUser(User user)
        {
            _users.Add(user);

        }

        public User GetUser(int userId)
        {
            return _users.FirstOrDefault(u => u.Id == userId);
        }

        public IEnumerable<User> GetUsers()
        {
            return _users;
        }

        public void Update(int userId, User u)
        {
            int ok = 0;
            foreach (User user in _users)
                if (user.Id == u.Id)
                {
                    ok=ok+1;
                    user.Email = u.Email;
                    user.Password = u.Password;
                    break;
                }
            if (ok == 0) throw new InvalidOperationException("Invalid user ID");

        }
    }
}