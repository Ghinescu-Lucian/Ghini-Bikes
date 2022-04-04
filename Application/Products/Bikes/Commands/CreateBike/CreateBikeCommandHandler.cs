using Domain.ProductFactory;
using Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Bikes.Commands.CreateBikeCommand
{
    public class CreateBikeCommandHandler : IRequestHandler<CreateBikeCommand, Bike>
    {
        private readonly IBikeRepository _repository;

        public CreateBikeCommandHandler(IBikeRepository repository)
        {
            _repository = repository;
        }
        public async Task<Bike> Handle(CreateBikeCommand request, CancellationToken cancellationToken)
        {
            var bikeFactory = BikeFactory.Instance;

            var bike = bikeFactory.CreateProductOfType(request.Type, request.Year, request.Price, request.Model, request.Manufacturer, request.Description);

           _repository.CreateBike(bike);

            return bike;
        }
    }
}
