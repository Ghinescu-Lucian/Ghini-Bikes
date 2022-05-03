using Domain.Models;
using Domain.ProductFactory;
using Domain.Products;
using MediatR;

namespace Application.Products.Parts.Commands.CreatePartCommand
{
    public class CreatePartCommandHandler : IRequestHandler<CreatePartCommand, Part>
    {
        private IPartRepository _partRepository;
        private IBikeRepository _bikeRepository;

        public CreatePartCommandHandler(IPartRepository partRepository,IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;
            _partRepository = partRepository;
        }
        public Task<Part> Handle(CreatePartCommand request, CancellationToken cancellationToken)
        {
            // id-ul bicicletei ( interogare )
            var partFactory = PartFactory.Instance;
            var part = partFactory.CreateProduct(request.Year, request.Price,request.Model, request.Manufacturer,request.Description);

            if (request.Compatibilities != null)
            {
                foreach (CompatibleItem b in request.Compatibilities)
                {

                    var bike = _bikeRepository.GetBikeById2(b.Bike.ProductId);
                    part.AddCompatibleBike(new CompatibleItem { Bike = bike });
                }
            }
            part.Images=request.Images;
            part.Quantity=request.Quantity;
            _partRepository.CreatePart(part);
            return Task.FromResult(part);

        }
    }
}
