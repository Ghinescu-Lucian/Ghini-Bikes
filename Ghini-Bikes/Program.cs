using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application;
using Application.Products.Accessories.Commands.CreateAccessoryCommand;
using Application.Products.Accessories.Commands.DeleteAccessoryCommand;
using Application.Products.Accessories.Commands.UpdateAccessoryCommand;
using Application.Products.Accessories.Queries.GetAccessoryById;
using Application.Products.Accessories.Queries.GetAllAccessories;
using Application.Users.Commands.CreateUser;
using Application.Users.Commands.DeleteUser;
using Application.Users.Commands.UpdateUser;
using Application.Users.Queries.GetUserByID;
using Application.Users.Queries.GetUsersList;
using Domain.Bikes;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace Bikes
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            var diContainer = new ServiceCollection()
                 .AddMediatR(typeof(IUserRepository))
                 .AddScoped<IUserRepository, InMemoryUserRepository>()
                 .AddScoped<IBikeRepository, InMemoryBikeRepository>()
                 .AddScoped<IPartRepository, InMemoryPartRepository>()
                 .AddScoped<IAccessoryRepository, InMemoryAccessoryRepository>()
                 .AddScoped<IOrderRepository, InMemoryOrderRepository>()
                 .BuildServiceProvider();

            var mediator = diContainer.GetRequiredService<IMediator>();

            var acc = await mediator.Send(new CreateAccessoryCommand
            {
                Manufacturer="Trelock",
                Model="LS-470",
                Price=275,
                Year=2022
            });
            Console.WriteLine(acc.productId+" "+acc.ToString());

            var acc3 = await mediator.Send(new UpdateAccessoryCommand
            {
                Id = acc.productId,
                Manufacturer = "Trelock 2",
                Model = "LS-450",
                Price = 280,
                Year = 2022
            }) ;

            var acc2 = await mediator.Send(new GetAccessoryByIdQuery
            {
                Id = 0
            });
            Console.WriteLine(acc2.productId +" "+acc);

            var acc4 = await mediator.Send(new GetAllAccessoriesQuery());
            Console.WriteLine(acc4.Last());
           

            
        }

    }
}