using Domain.Bikes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Accessories.Commands.CreateAccessoryCommand
{
    public class CreateAccessoryCommandHandler : IRequestHandler<CreateAccessoryCommand, Accessory>
    {
        private readonly IAccessoryRepository _repository;

        public CreateAccessoryCommandHandler(IAccessoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Accessory> Handle(CreateAccessoryCommand request, CancellationToken cancellationToken)
        {
            var accessory = new Accessory()
            {
                Manufacturer = request.Manufacturer,
                Model = request.Model,
                Description = request.Description,
                Year = request.Year,
                Price = request.Price
            };

            _repository.CreateAccessory(accessory);

            return accessory;

        }

       
    }
}
