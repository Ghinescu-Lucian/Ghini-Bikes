using Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Bikes.Commands.DeleteBikeCommand
{
    public class DeleteBikeCommandHandler : IRequestHandler<DeleteBikeCommand, Bike>
    {
        private readonly IBikeRepository _repository;

        public DeleteBikeCommandHandler(IBikeRepository repository)
        {
            _repository = repository;
        }
      

        public async Task<Bike> Handle(DeleteBikeCommand request, CancellationToken cancellationToken)
        {
            var bike = new Bike()
            {
               Manufacturer=request.Manufacturer,
               Model=request.Model,
               Year=request.Year
            };

            _repository.DeleteBike(bike);

            return bike;
        }
    }
}
