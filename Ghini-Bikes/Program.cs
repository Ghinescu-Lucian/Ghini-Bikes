using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application;
using Application.Users.Commands.CreateUser;
using Application.Users.Queries.GetUsersList;
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
                 .BuildServiceProvider();

            var mediator = diContainer.GetRequiredService<IMediator>();

            var userId = await mediator.Send(new CreateUserCommand
            {
                Username = "Luky",
                Password = "1234",
                Email = "luky@gmail.com"
            });
            Console.WriteLine("User creat cu id-ul : "+userId);
            var users = await mediator.Send(new GetUsersListQuery());

            foreach(var user in users)
                Console.WriteLine(user);

        }

    }
}