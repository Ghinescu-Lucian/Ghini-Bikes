using Domain.Models;
using Domain.Products;
using MediatR;

namespace Application.Products.Bikes.Queries.GetBikeById
{
    public class GetBikeByIdQueryHandler : IRequestHandler<GetBikeByIdQuery, Product>
    {
        private readonly IBikeRepository _repository;

        public GetBikeByIdQueryHandler(IBikeRepository repository)
        {
            _repository = repository;
        }
        public Task<Product> Handle(GetBikeByIdQuery request, CancellationToken cancellationToken)
        {
            var bike = _repository.GetBikeById(request.Id);
            return Task.FromResult(bike);
        }
    }
}
