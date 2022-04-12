using Domain.Models;
using Domain.Products;
using MediatR;

namespace Application.Products.Parts.Queries.GetAllParts
{
    public class GetAllPartsQueryHandler : IRequestHandler<GetAllPartsQuery, IEnumerable<Product>>
    {
        private IPartRepository _partRepository;

        public GetAllPartsQueryHandler(IPartRepository repository)
        {
            _partRepository = repository;
        }
        public Task<IEnumerable<Product>> Handle(GetAllPartsQuery request, CancellationToken cancellationToken)
        {
            var result = _partRepository.GetParts();
            return Task.FromResult(result);
        }
    }
}
