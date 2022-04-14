using Domain.Products;
using MediatR;

namespace Application.Products.Accessories.Queries.GetAccessoryById
{
    public class GetAccessoryByIdQuery : IRequest<Accessory>
    {
        public int Id { get; set; }
    }
}
