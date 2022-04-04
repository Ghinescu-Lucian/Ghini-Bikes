using Domain.Bikes;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Accessories.Queries.GetAllAccessories
{
    public class GetAllAccessoriesQueryHandler : IRequestHandler<GetAllAccessoriesQuery, IEnumerable<Accessory>>
    {
        private readonly IAccessoryRepository _repository;

        public GetAllAccessoriesQueryHandler(IAccessoryRepository accessoryRepository)
        {
            _repository = accessoryRepository;
        }

        public Task<IEnumerable<Accessory>> Handle(GetAllAccessoriesQuery request, CancellationToken cancellationToken)
        {
            var result = _repository.GetAccessories();
            return Task.FromResult(result);
        }
    }
}
