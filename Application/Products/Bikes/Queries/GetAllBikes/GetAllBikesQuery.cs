using Domain.Models;
using Domain.Products;
using MediatR;


namespace Application.Products.Bikes.Queries.GetAllBikes
{
    public class GetAllBikesQuery : IRequest<IEnumerable<Product>>
    {
    }
}
