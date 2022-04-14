using Application;
using Application.Orders.Queries.GetAllOrders;
using Application.Products.Accessories.Commands.CreateAccessoryCommand;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;
using Application.Products.Accessories.Queries.GetAllAccessories;
using System.Linq;
using Domain.Bikes;
using Domain.Users;
using Domain.Models;
using Domain.Products;
using System;
using Infrastructure.Repositories;

namespace UnitTests
{
    [TestFixture]
    public class ProductsTests
    {

        [TestCase]
        public async Task TestCreateAccessory()
        {
            var diContainer = new ServiceCollection()
                .AddMediatR(typeof(IUserRepository))
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IBikeRepository, BikeRepository>()
                .AddScoped<IPartRepository, PartRepository>()
                .AddScoped<IAccessoryRepository, AccessoryRepository>()
                .AddScoped<IOrderRepository, OrderRepository>()
                .BuildServiceProvider();

            var mediator = diContainer.GetRequiredService<IMediator>();
            var acc1 = await mediator.Send(new GetAllAccessoriesQuery());
            Assert.That(acc1.Count() == 0);
            var acc = await mediator.Send(new CreateAccessoryCommand
            {
                Manufacturer = "Trelock",
                Model = "LS-470",
                Price = 275,
                Year = 2022
            });

             acc1 = await mediator.Send(new GetAllAccessoriesQuery());

            Assert.That(acc1.Count() == 1);
            Assert.That(string.Equals(acc1.First().Manufacturer, "Trelock"));
        }

        [Test]
        public void TestCoeficientCalculator()
        {
            ElectricBike e = new ElectricBike();
            e.Manufacturer = "Cube";
            e.Model = "Stereo hybrid";
            e.Price = 12000;
            e.Year = 2022;

            double x = e.Coeficient(3);
            Console.WriteLine(x);
            Assert.That(x == 8.93);


        }
       
    }
}