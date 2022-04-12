using MediatR;
using Domain.Products;
using Domain.Models;

namespace Application.Products.Bikes.Commands.CreateBikeCommand
{
    public class CreateBikeCommand : IRequest<Bike>
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public Image _Image { get; set; }
        public double Weight { get; set; }
        public int WarrantyMonths { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }

    }
}
