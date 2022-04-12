using Domain.Models;
using Domain.Products;
using MediatR;


namespace Application.Products.Bikes.Queries.GetAllBikes
{
    public class GetAllBikesQueryHandler : IRequestHandler<GetAllBikesQuery, IEnumerable<Product>>
    {
        private readonly IBikeRepository _repository;
        
        public GetAllBikesQueryHandler(IBikeRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Product>> Handle(GetAllBikesQuery request, CancellationToken cancellationToken)
        {
            var result = _repository.GetBikes();
            return Task.FromResult(result);
        }
    }
}
