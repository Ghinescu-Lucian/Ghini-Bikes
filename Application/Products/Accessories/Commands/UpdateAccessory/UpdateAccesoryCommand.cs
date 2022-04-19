using Domain.Models;
using Domain.Products;
using MediatR;

namespace Application.Products.Accessories.Commands.UpdateAccessoryCommand
{
    public class UpdateAccessoryCommand : IRequest<Accessory>
    {
        public int Id { get; set; } 
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public string Model { get; set; }
        public List<Image> Images { get; set; }
        public int Quantity { get; set; }
    }
}
