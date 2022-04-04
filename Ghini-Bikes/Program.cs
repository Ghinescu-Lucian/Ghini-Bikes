﻿using Application;
using Application.Products.Accessories.Commands.CreateAccessoryCommand;
using Application.Products.Accessories.Commands.DeleteAccessoryCommand;
using Application.Products.Accessories.Commands.UpdateAccessoryCommand;
using Application.Products.Accessories.Queries.GetAccessoryById;
using Application.Products.Accessories.Queries.GetAllAccessories;
using Application.Products.Bikes.Commands.CreateBikeCommand;
using Application.Products.Bikes.Commands.DeleteBikeCommand;
using Application.Products.Bikes.Commands.UpdateBikeCommand;
using Application.Products.Bikes.Queries.GetAllBikes;
using Application.Products.Bikes.Queries.GetBikeById;
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

            var bike = await mediator.Send(new CreateBikeCommand
            {
                Type = "MTBBike",
                Manufacturer = "Cube",
                Model = "AIM",
                Year = 2022,
                Price = 3799,
                WarrantyMonths = 24,
                Description = "Duralumin frame, hydraulic brakes",
                Weight = 13.5

            }) ;
            var MTBbike = await mediator.Send(new CreateBikeCommand
            {
                Type = "MTBBike",
                Manufacturer = "Cube",
                Model = "AIM",
                Year = 2022,
                Price = 3799,
                WarrantyMonths = 24,
                Description = "Duralumin frame, hydraulic brakes",
                Weight = 13.5

            });

            Console.WriteLine(" " + bike);

            /*var bike2 = await mediator.Send(new DeleteBikeCommand
            {
                Manufacturer= bike.Manufacturer,
                Model= bike.Model,
                Year=bike.Year

            });*/
            var bike3 = await mediator.Send(new UpdateBikeCommand
            {
                Id = 0,
                Manufacturer = "FOCUS",
                Model = "HIGHLAND PEAK",
                Price = 1890,
                Weigth = 13,
                Year = bike.Year,
                Description = "Duralumin frame, mecahnic disc brakes",
                WarrantyMonths = 24
            }) ;
            Console.WriteLine(bike3 + " ");

            var bike4 = await mediator.Send(new GetAllBikesQuery());
            Console.WriteLine(bike4.Last() +" "+ bike4.Last().productId);

            var bike5 = await mediator.Send(new GetBikeByIdQuery { Id = 1 });
            Console.WriteLine(" By ID "+bike5.Manufacturer);    
           

            
        }

    }
}