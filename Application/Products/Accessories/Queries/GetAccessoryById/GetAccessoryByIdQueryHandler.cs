using Domain.Bikes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Accessories.Queries.GetAccessoryById
{
    public class GetAccessoryByIdQueryHandler : IRequestHandler<GetAccessoryByIdQuery, Accessory>
    {
        private readonly IAccessoryRepository _repository;

        public GetAccessoryByIdQueryHandler(IAccessoryRepository accessoryRepository)
        {
            _repository = accessoryRepository;
        }


        Task<Accessory> IRequestHandler<GetAccessoryByIdQuery, Accessory>.Handle(GetAccessoryByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _repository.GetAccessoryById(request.Id);
            return Task.FromResult(result);
        }
    }
}
