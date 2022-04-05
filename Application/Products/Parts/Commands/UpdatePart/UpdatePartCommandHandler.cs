using Domain.Products;
using MediatR;

namespace Application.Products.Parts.Commands.UpdatePartCommand
{
    public class UpdatePartCommandHandler : IRequestHandler<UpdatePartCommand, Part>
    {
        private IPartRepository _partRepository;

        public UpdatePartCommandHandler(IPartRepository repository)
        {
                _partRepository = repository;
        }
        public Task<Part> Handle(UpdatePartCommand request, CancellationToken cancellationToken)
        {
            var partUpdate = new Part
            {
                Manufacturer = request.Manufacturer,
                Model = request.Model,
                Description = request.Description,
                Year = request.Year,
                Price = request.Price
            };
            return Task.FromResult(partUpdate);
        }
    }
}
