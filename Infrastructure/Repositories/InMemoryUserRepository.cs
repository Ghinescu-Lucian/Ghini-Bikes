
using Application;
using Domain.Models;

namespace Infrastructure
{
    /// <summary>
    /// User (products) repository cache
    /// </summary>
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> _users = new();

        public void CreateUser(User user)
        {
            _users.Add(user);

        }

        public User DeleteUser(int userId)
        {
            var userRemove = _users.Single( u => u.Id == userId);
            try { 
                
                _users.Remove(userRemove);
            }
            catch (Exception e){
                Console.WriteLine(e.Message); 
            }
            return userRemove;
        }

        public User GetUserById(int userId)
        {
            return _users.FirstOrDefault(u => u.Id == userId);
        }

        public IEnumerable<User> GetUsers()
        {
            return _users;
        }

        public void UpdateUser(int userId, User u)
        {
            int ok = 0;
            foreach (User user in _users)
                if (user.Id == userId)
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