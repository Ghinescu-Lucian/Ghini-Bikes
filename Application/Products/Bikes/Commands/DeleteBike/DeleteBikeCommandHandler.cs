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
           

            var bike= _repository.DeleteBike(request.Id);

            return bike;
        }
    }
}
