using Domain.Products;
using MediatR;

namespace Application.Products.Accessories.Commands.DeleteAccessoryCommand
{
    public class DeleteAccessoryCommandHandler : IRequestHandler<DeleteAccessoryCommand, Accessory>
    {
        private readonly IAccessoryRepository _repository;

        public DeleteAccessoryCommandHandler(IAccessoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Accessory> Handle(DeleteAccessoryCommand request, CancellationToken cancellationToken)
        {
           

            var accessory= _repository.DeleteAccessory(request.Id);

            return accessory;

        }

       
    }
}
