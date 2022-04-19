using Domain.Products;
using MediatR;

namespace Application.Products.Accessories.Commands.DeleteAccessoryCommand
{
    public class DeleteAccessoryCommand : IRequest<Accessory>
    {
      public int Id { get; set; }
       
    }
}
