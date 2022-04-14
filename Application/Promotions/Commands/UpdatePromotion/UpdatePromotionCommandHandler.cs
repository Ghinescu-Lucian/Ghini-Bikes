using Domain.Models;
using MediatR;

namespace Application.Promotions.Commands.UpdatePromotion
{
    public class UpdatePromotionCommandHandler : IRequestHandler<UpdatePromotionCommand,PromoPackage>
    {
        private IPromotionRepository _promotionRepository;

        public UpdatePromotionCommandHandler(IPromotionRepository repository)
        {
            _promotionRepository = repository;
        }

        public Task<PromoPackage> Handle(UpdatePromotionCommand request, CancellationToken cancellationToken)
        {

             _promotionRepository.UpdatePromotion(request.Id,request.Package);
            return Task.FromResult(request.Package);
        }
    }
}
