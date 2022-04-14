using Domain.Products;
using MediatR;

namespace Application.Products.Accessories.Commands.DeleteAccessoryCommand
{
    public class DeleteAccessoryCommand : IRequest<Accessory>
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
       
    }
}
