using Domain.Bikes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Accessories.Commands.UpdateAccessoryCommand
{
    public class UpdateAccessoryCommandHandler : IRequestHandler<UpdateAccessoryCommand, Accessory>
    {
        private readonly IAccessoryRepository _repository;

        public UpdateAccessoryCommandHandler(IAccessoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Accessory> Handle(UpdateAccessoryCommand request, CancellationToken cancellationToken)
        {
            var accessory = new Accessory()
            {
                Manufacturer = request.Manufacturer,
                Model = request.Model,
                Year = request.Year,
                Price = request.Price,
                Description = request.Description,
            };

            _repository.UpdateAccessory(request.Id,accessory);

            return accessory;

        }

       
    }
}
