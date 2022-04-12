using Domain.Models;
using Domain.Products;
using MediatR;

namespace Application.Products.Parts.Queries.GetPartById
{
    public class GetPartByIdQueryHandler :IRequestHandler<GetPartByIdQuery, Product>
    {
        private IPartRepository _partRepository;

        public GetPartByIdQueryHandler(IPartRepository repository)
        {
            _partRepository = repository;
        }

        public Task<Product> Handle(GetPartByIdQuery request, CancellationToken cancellationToken)
        {
            var part = _partRepository.GetPartById(request.Id);
            return Task.FromResult(part);
        }
    }
}
