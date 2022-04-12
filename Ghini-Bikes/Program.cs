using Application;
using Application.Orders.Commands.CreateOrderCommand;
using Application.Products.Bikes.Commands.CreateBikeCommand;
using Application.Products.Bikes.Queries.GetAllBikes;
using Application.Users.Commands.CreateUser;
using Application.Users.Commands.DeleteUser;
using Application.Users.Commands.UpdateUser;
using Application.Users.Queries.GetUserByID;
using Application.Users.Queries.GetUsersList;
using Domain.Models;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Ghini_Bikes
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            var diContainer = new ServiceCollection()
                 .AddDbContext<ShopDbContext>(options => options.UseSqlServer("Server=DESKTOP-C8L0AG5\\LUCHI;Database=GhiniBikes;Trusted_Connection=True"))
                 .AddMediatR(typeof(IUserRepository))
                 .AddScoped<IUserRepository,UserRepository>()
                 .AddScoped<IBikeRepository, BikeRepository>()
                 .AddScoped<IPartRepository, InMemoryPartRepository>()
                 .AddScoped<IAccessoryRepository, InMemoryAccessoryRepository>()
                 .AddScoped<IOrderRepository, OrderRepository>()
                 .BuildServiceProvider();

            var mediator = diContainer.GetRequiredService<IMediator>();

            //var user = await mediator.Send(new CreateUserCommand{ Email = "lucian.ghinescu@amdaris.com", Username = "Lucian-Calin", Password = "123456789" });
            var users = await mediator.Send(new GetUsersListQuery());
            var user = users.First();
         //   var user2 = await mediator.Send(new GetUserByIDQuery { UserId = 10 }) ;
          //  var user3 = await mediator.Send(new DeleteUserCommand { UserId=8});
          //  var user = await mediator.Send(new UpdateUserCommand { Email = "lucianghinescu@gmail.com", Username = "Lucian", Password = "1", UserId = 1 });
            //Console.WriteLine(user.Email);

            /*var bike1 = await mediator.Send(new CreateBikeCommand
            {
                Description = "Duralumin frame",
                Manufacturer = "Focus",
                Model = "HighLand Peak",
                Year = 2014,
                Price = 1899,
                Weight = 13,
                WarrantyMonths = 24,
                Quantity = 2,
                Type = "MTBBike",
                _Image = new Image { Path = "1.png" }

            }) ;*/
            var bike2 = await mediator.Send(new GetAllBikesQuery());
            var bike3 = bike2.First();
 
           // bike3.Quantity = 1;
            List<OrderItem> items = new List<OrderItem> { new OrderItem { _Product = bike3, Quantity=1 } };
            var order1 = await mediator.Send(new CreateOrderCommand
            {
                User = user,
                Items = items,
                Date = DateTime.Now,
                TelephoneNr = "0727217169",
                Address = "Strada X",
                Payment = Domain.Enums.Payment.Cash,
                ShippingMethod = "Personal"
            });

        }

    }
}