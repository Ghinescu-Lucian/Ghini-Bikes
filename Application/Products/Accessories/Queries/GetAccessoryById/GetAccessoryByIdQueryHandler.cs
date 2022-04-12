using Domain.Bikes;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Accessories.Queries.GetAccessoryById
{
    public class GetAccessoryByIdQueryHandler : IRequestHandler<GetAccessoryByIdQuery, Product>
    {
        private readonly IAccessoryRepository _repository;

        public GetAccessoryByIdQueryHandler(IAccessoryRepository accessoryRepository)
        {
            _repository = accessoryRepository;
        }


        Task<Product> IRequestHandler<GetAccessoryByIdQuery, Product>.Handle(GetAccessoryByIdQuery request, CancellationToken cancellationToken)
        {
            var result = _repository.GetAccessoryById(request.Id);
            return Task.FromResult(result);
        }
    }
}
