using Domain.Exceptions;
using Domain.Users;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestFixture]
    public class UserTests
    {
        // just a single scenario in a test method
        [Test]
        public void TestUserLogIn_WhenAnInvalidPassword_ThenExceptionThrown()
        {
            NormalUser u = new NormalUser()
            {
                Username = "Luky",
                Password = "1234",
                Email = "luky@gmail.com"

            };

            Exception exception = Assert.Throws<InvalidCredentialsException>(() => u.LogIn("123"));
            Assert.That(exception.Message, Is.EqualTo("Wrong password!"));

         /*   u.LogIn("1234");
            Assert.That(u.LoggedIn==true);

            u.LogOut();
            Assert.That(u.LoggedIn==false); */
        }
    }
}
