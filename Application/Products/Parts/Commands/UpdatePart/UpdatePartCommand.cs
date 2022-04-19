using Domain.Models;
using Domain.Products;
using MediatR;

namespace Application.Products.Parts.Commands.UpdatePartCommand
{
    public class UpdatePartCommand : IRequest<Part>
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public List<Image> Images { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public List<CompatibleItem> Compatibities { get; set; }
    }
}
