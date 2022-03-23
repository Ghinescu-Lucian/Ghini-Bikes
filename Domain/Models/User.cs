using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public abstract class User
    {
        private static int initialID = 0;
        private int id;
        private string username;
        private string password;
        public string email;
        private bool loggedIn;
        public string Username { get {  return this.username; } set { username = value; } }
        public bool LoggedIn { get { return this.loggedIn; } set { this.loggedIn = value; } }
        public User(string username,string password, string email)
        {
            this.email = email;
            this.username = username;   
            this.password = password;
            initialID = initialID + 1;
        }

        public override string ToString()
        {
            return username + ":" + email;
        }

        public void LogIn(string password)
        {
            if (!String.Equals(password,this.password))
                throw new InvalidCredentialsException("Wrong password!");
            else Console.WriteLine($" {Username} is logged in!");
            this.loggedIn = true;

        }
        public void LogOut()
        {
            this.loggedIn = false;
        }

    }
}
