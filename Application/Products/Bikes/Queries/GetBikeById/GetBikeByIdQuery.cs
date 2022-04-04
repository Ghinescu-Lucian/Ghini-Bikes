using Domain.Products;
using MediatR;


namespace Application.Products.Bikes.Queries.GetBikeById
{
    public class GetBikeByIdQuery : IRequest<Bike>
    {
        public int Id { get; set; }
    }
}
