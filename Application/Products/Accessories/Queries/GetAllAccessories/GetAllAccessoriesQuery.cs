using Domain.Bikes;
using Domain.Products;
using MediatR;


namespace Application.Products.Accessories.Queries.GetAllAccessories
{
    public class GetAllAccessoriesQuery : IRequest<IEnumerable<Accessory>>
    {
    }
}
