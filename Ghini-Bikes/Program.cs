using Application;
using Application.Orders.Commands.CreateOrderCommand;
using Application.Orders.Commands.DeleteOrderCommand;
using Application.Orders.Queries.GetAllOrders;
using Application.Orders.Queries.GetOrdersByUser;
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
using Application.Products.Parts.Commands.CreatePartCommand;
using Application.Products.Parts.Queries.GetAllParts;
using Application.Products.Parts.Queries.GetPartById;
using Application.Users.Commands.CreateUser;
using Domain.Models;
using Domain.Products;
using Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace Ghini_Bikes
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

            Console.WriteLine("\n   Accessory\n");

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
            Console.WriteLine("\n   Bike\n");
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

            Console.WriteLine("\n   Part\n");
            List<Bike> bikeList = new List<Bike>();
            bikeList.Add(bike5);
            Console.WriteLine("Bike nr "+bikeList.Count );
            var part = await mediator.Send(new CreatePartCommand
            {
                Manufacturer = "Shimano",
                Model = "Altus",
                Year = 2022,
                Price = 129,
                Description = "Schimbator spate 8 viteze",
                Bikes = bikeList
            });

            var part2 = await mediator.Send(new GetAllPartsQuery());
            Console.WriteLine(part2.Last() + " "+ part2.Last().productId);
            var part3 = await mediator.Send(new GetPartByIdQuery { Id = 1 });
            Console.WriteLine(part3);

            Console.WriteLine("\n   Order");

            var user = await mediator.Send(new CreateUserCommand
            {
                Username = "Luky",
                Password = "1234",
                Email = "Luky@gmail.com"
            });

            List<Product> products = new List<Product> { bike5, acc2 };
            var order1 = await mediator.Send(new CreateOrderCommand
            {
                User = user,
                products = products,
                Date= DateTime.Now,
                TelephoneNr = "0727217169",
                Address ="Strada X",
                Payment = Domain.Enums.Payment.Cash,
                ShippingMethod = "Personal"
            });
            Console.WriteLine("Id-ul comenzii e: "+ order1.Id + order1.User);

            var order2 = await mediator.Send(new DeleteOrderCommand
            {
                Id = order1.Id
            });

            order1 = await mediator.Send(new CreateOrderCommand
            {
                User= user,
                products = products,
                Date = DateTime.Now,
                TelephoneNr = "0727217169",
                Address = "Strada X",
                Payment = Domain.Enums.Payment.Cash,
                ShippingMethod = "Personal"
            });
            var order3 = await mediator.Send(new GetAllOrdersQuery());
           Console.WriteLine("Order3    "+order3.Count());
           var order4 = await mediator.Send(new GetOrdersByUserQuery
            {
                User= user
            });
            Console.WriteLine("By User      "+order4.First());


        }

    }
}