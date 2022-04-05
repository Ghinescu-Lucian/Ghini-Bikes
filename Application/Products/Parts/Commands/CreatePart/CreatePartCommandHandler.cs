using Domain.ProductFactory;
using Domain.Products;
using MediatR;

namespace Application.Products.Parts.Commands.CreatePartCommand
{
    public class CreatePartCommandHandler : IRequestHandler<CreatePartCommand, Part>
    {
        private IPartRepository _partRepository;

        public CreatePartCommandHandler(IPartRepository repository)
        {
            _partRepository = repository;
        }
        public Task<Part> Handle(CreatePartCommand request, CancellationToken cancellationToken)
        {
            var partFactory = PartFactory.Instance;
            var part = partFactory.CreateProduct(request.Year, request.Price,request.Model, request.Manufacturer,request.Description);
            foreach(Bike b in request.Bikes)
                part.AddCompatibleBike(b);
            _partRepository.CreatePart(part);
            return Task.FromResult(part);

        }
    }
}
