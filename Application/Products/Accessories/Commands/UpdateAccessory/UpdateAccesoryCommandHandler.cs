using Domain.Products;
using MediatR;

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
                Images = request.Images
            };

            _repository.UpdateAccessory(request.Id,accessory);

            return accessory;

        }

       
    }
}
