using NUnit.Framework;
using System.Threading.Tasks;
using Domain.Bikes;
using Domain.Users;
using Domain.Models;
using Domain.Products;


namespace UnitTests
{
    [TestFixture]
    public class OrderTests
    {

        [TestCase]
        public async Task TaskTestShoppingCost()
        {
            NormalUser u = new NormalUser()
            {
                Username = "Luky",
                Password = "1234",
                Email = "luky@gmail.com"

            };
            u.LogIn("1234");
            Accessory a = new Accessory()
            {
                Manufacturer = "Sram",
                Year = 2022,
                Model = "Ring",
                Description = "Claxon",
                Price = 20

            };
            u.AddToCart(a);
            Order order = u.Place_Order("Courier");

            Assert.That(order.FinalCost == 45); // adauga 25 pt transport

            MTBBike b = new MTBBike()
            {
                Manufacturer = "FOCUS",
                Price = 3500,
                Model = "HighLand Peak",
                Year = 2014,
                WarrantyMonths = 24,
                Suspension = "SR Sountour",
                Specification = "Duralumin frame"

            };
            u.AddToCart(b);
            order = u.Place_Order("Courier");
            Assert.That(order.FinalCost == 3500);

            u.AddToCart(a);
            order= u.Place_Order("Personal");
            Assert.That(order.FinalCost == 20);


        }
    }
}
