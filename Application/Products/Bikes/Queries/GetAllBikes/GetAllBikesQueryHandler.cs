using Domain.Products;
using MediatR;


namespace Application.Products.Bikes.Queries.GetAllBikes
{
    public class GetAllBikesQueryHandler : IRequestHandler<GetAllBikesQuery, IEnumerable<Bike>>
    {
        private readonly IBikeRepository _repository;
        
        public GetAllBikesQueryHandler(IBikeRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Bike>> Handle(GetAllBikesQuery request, CancellationToken cancellationToken)
        {
            var result = _repository.GetBikes();
            return Task.FromResult(result);
        }
    }
}
