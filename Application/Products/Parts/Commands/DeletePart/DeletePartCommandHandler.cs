using Domain.Products;
using MediatR;

namespace Application.Products.Parts.Commands.DeletePartCommand
{
    public class DeletePartCommandHandler : IRequestHandler<DeletePartCommand, Part>
    {
        private IPartRepository _partRepository;

        public DeletePartCommandHandler(IPartRepository repository)
        {
            _partRepository = repository;
        }

         public Task<Part> Handle(DeletePartCommand request, CancellationToken cancellationToken)
        {
            var part = new Part
            {
                Manufacturer = request.Manufacturer,
                Model = request.Model,
                Year = request.Year
            };
            _partRepository.DeletePart(part);
            return Task.FromResult(part);
        }
    }
}
