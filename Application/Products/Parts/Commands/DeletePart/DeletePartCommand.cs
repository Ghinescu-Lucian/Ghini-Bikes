using Domain.Products;
using MediatR;


namespace Application.Products.Parts.Commands.DeletePartCommand
{
    public class DeletePartCommand : IRequest<Part>
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}
