using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }

        public bool LoggedIn { get; set; }
        public List<Order> Orders { get; set; }
       
        public User()
        {
            Orders = new List<Order>();
        }
        public override string ToString()
        {
            return Username + ":" + Email;
        }

        public void LogIn(string password)
        {
            if (!String.Equals(password,Password))
                throw new InvalidCredentialsException("Wrong password!");
            else Console.WriteLine($" {Username} is logged in!");
            this.LoggedIn = true;

        }
        public void LogOut()
        {
            this.LoggedIn = false;
        }

        public bool Equals(Object obj)
        {
            if ( obj == null) 
                return false;
            User u = obj as User;
            if (string.Equals(u.Username, Username) && u.Id == this.Id)
                return true;
            return false;
        }
        public int GetHashCode()
        {
            return Id.GetHashCode();
        }


    }
}
