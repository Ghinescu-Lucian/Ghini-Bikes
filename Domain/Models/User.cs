using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        private static int initialID = 0;
        
        private string username;
        public  string Password { get; set; }
        public string Email { get; set; }
        private bool loggedIn;
        public string Username { get {  return this.username; } set { username = value; } }
        public bool LoggedIn { get { return this.loggedIn; } set { this.loggedIn = value; } }
        public int Id { get; set; }
        public User()
        {
            Id = initialID++;
        }

        public override string ToString()
        {
            return username + ":" + Email;
        }

        public void LogIn(string password)
        {
            if (!String.Equals(password,Password))
                throw new InvalidCredentialsException("Wrong password!");
            else Console.WriteLine($" {Username} is logged in!");
            this.loggedIn = true;

        }
        public void LogOut()
        {
            this.loggedIn = false;
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
