using Application;
using Application.Products.Parts.Queries.GetAllParts;
using Application.Products.Accessories.Queries.GetAllAccessories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Application.Products.Bikes.Queries.GetAllBikes;
using Application.Users.Queries.GetUserByID;
using Application.Orders.Queries.GetOrdersByUser;
using Application.Orders.Queries.GetAllOrders;
using Application.Orders.Queries.GetOrderById;
using Application.Users.Queries.GetUsersList;
using Application.Promotions.Commands.CreatePromotion;
using Domain.Models;
using Application.Products.Parts.Commands.CreatePartCommand;
using Domain.Products;
using Application.Products.Bikes.Commands.CreateBikeCommand;

namespace Ghini_Bikes
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            var diContainer = new ServiceCollection()
                 .AddDbContext<ShopDbContext>(options => options.UseSqlServer("Server=DESKTOP-C8L0AG5\\LUCHI;Database=GhiniBikes;Trusted_Connection=True"))
                 .AddMediatR(typeof(IUserRepository))
                 .AddScoped<IUserRepository, UserRepository>()
                 .AddScoped<IBikeRepository, BikeRepository>()
                 .AddScoped<IPartRepository, PartRepository>()
                 .AddScoped<IAccessoryRepository, AccessoryRepository>()
                 .AddScoped<IOrderRepository, OrderRepository>()
                 .AddScoped<IImageRepository, ImageRepository>()
                 .AddScoped<IPromotionRepository, PromotionRepository>()
                 .BuildServiceProvider();

            var mediator = diContainer.GetRequiredService<IMediator>();
            /*
                           User user1;
                            for(int i = 0; i < 10; i++)
                            {
                                 user1 = await mediator.Send(new CreateUserCommand {Email = "user"+i + " @gmail.com" , Username="user"+i,Password="1234"});
                            }
                            Product product;
                            for(int i=0;i< 5; i++)
                            {
                                product = await mediator.Send(new CreateBikeCommand {Description="bike"+i,Manufacturer="Producer "+i,
                                    Model=i+"",Price=2000,Weight=13,Quantity=2,
                                    WarrantyMonths=24,
                                    Type="Bike",
                                    Year=2022,
                                    Images= new List<Image> { new Image { Path = i + ".png" } }
                                });
                            }
                             Accessory acc;
                             for (int i = 0; i < 5; i++)
                             {
                                 acc = await mediator.Send(new CreateAccessoryCommand
                                 {
                                     Description = "description " + i,
                                     Manufacturer = "Producer " + i,
                                     Model =i+"",
                                     Year=2022,
                                     Price=i,
                                     Images = new List<Image> { new Image { Path = i + ".png" } }
                                 }) ;
                             }
                            var products1 = await mediator.Send(new GetAllBikesQuery());
                            var productList=products1.Take(2).ToList();
                            Part part;
                            for(int i = 0; i < 5; i++)
                            {
                                part = await mediator.Send(new CreatePartCommand
                                {
                                    Description = "description " + i,
                                    Manufacturer = "Producer " + i,
                                    Model = i + "",
                                    Year = 2022,
                                    Price = i,
                                    Bikes = productList,
                                    Images = new List<Image> { new Image { Path = i + ".png" } , new Image { Path = i+"1.jpg"} }
                                });
                            }



                            var user = await mediator.Send(new GetUserByIDQuery { UserId = 1 });
                            var products = await mediator.Send(new GetAllBikesQuery());
                            var products2 = products.Take(2).ToList();
                            List<OrderItem> items = new List<OrderItem> { new OrderItem { _Product=products2[0], Quantity=1}, new OrderItem { _Product = products2[1], Quantity=1 } };
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


                        var user = await mediator.Send(new GetUserByIDQuery { UserId = 1 });
                        var users = await mediator.Send(new GetUsersListQuery());
                        var products1 = await mediator.Send(new GetAllBikesQuery());
                        var productList = products1.Take(3).ToList();
                        var compatibleList = new List<CompatibleItem> { new CompatibleItem { Bike=productList[0]}, new CompatibleItem { Bike=productList[1]} };

                        Part part;
                        part = await mediator.Send(new CreatePartCommand
                        {
                            Description = "description " + 10,
                            Manufacturer = "Producer " + 10,
                            Model = 10 + "",
                            Year = 2022,
                            Price = 10,
                            Bikes = compatibleList,
                            Images = new List<Image> { new Image { Path = 10 + ".png" }, new Image { Path = 10 + "1.jpg" } }
                        });
                        /*
                        //  var part1Compatibilities = parts.Last().Compatibilities.Count();

                          List<PromoItem> items = new List<PromoItem> { new PromoItem { _Product = bikes.First(), Discount = 30, Quantity = 1 } };
                          var promoPack = await mediator.Send(new CreatePromotionCommand
                          {
                              Name = " Winter sale ",
                              Items = items
                          });

                          Console.WriteLine("First bike has " + bike1Pictures + " photos");
                         // Console.WriteLine("Last part has " + part1Compatibilities + " compatibilities");
                          Console.WriteLine("User by id: " + user.Username);
                          Console.WriteLine("Users list first:" + users.Last().Username);
                         // Console.WriteLine("Parts last: " + parts.Last().Manufacturer);
                          Console.WriteLine("Accessories first:" + accessories.First().Manufacturer);
                          Console.WriteLine("Bikes last:" + bikes.Last().Manufacturer);
                          Console.WriteLine("Orders count:" + orders.Count());
                          Console.WriteLine("Orders by userid:" + ordersByUser2[0].Address);
                          Console.WriteLine("Order 1 items:" + orders.First().Items.Count());
                          Console.WriteLine("Nr biciclete " + bikes.Count());
                        */
          /*  Product product;
            product = await mediator.Send(new CreateBikeCommand
            {
                Description = "bike",
                Manufacturer = "Producer ",
                Model = "11111",
                Price = 2000,
                Weight = 13,
                Quantity = 2,
                // WarrantyMonths = 24,
                Type = "Bike",
                Year = 2022,
                Images = new List<Image> { new Image { Path = "ladl;s" + ".png" } }
            });*/




        }
    }
}