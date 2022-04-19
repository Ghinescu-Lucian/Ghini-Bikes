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
            var part = _partRepository.DeletePart(request.Id);
            return Task.FromResult(part);
        }
    }
}
