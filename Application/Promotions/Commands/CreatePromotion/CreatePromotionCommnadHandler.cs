using Domain.Models;
using MediatR;

namespace Application.Promotions.Commands.CreatePromotion
{
    public class CreatePromotionCommandHandler : IRequestHandler<CreatePromotionCommand,PromoPackage>
    {
        private IPromotionRepository _promotionRepository;

        public CreatePromotionCommandHandler(IPromotionRepository repository)
        {
            _promotionRepository = repository;
        }

        public Task<PromoPackage> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
        {
           var package = new PromoPackage
           {
               Name = request.Name,
               Items = request.Items
           };
            _promotionRepository.CreatePromotion(package);
            return Task.FromResult(package);
        }
    }
}
