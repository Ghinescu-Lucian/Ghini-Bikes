using Domain.Models;
using Domain.Products;
using MediatR;


namespace Application.Products.Bikes.Commands.UpdateBikeCommand
{
    public class UpdateBikeCommand : IRequest<Bike>
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int WarrantyMonths { get; set; }
        public double Price { get; set; }
        public double Weigth { get; set; }
        public List<Image> Images { get; set; }

    }
}
