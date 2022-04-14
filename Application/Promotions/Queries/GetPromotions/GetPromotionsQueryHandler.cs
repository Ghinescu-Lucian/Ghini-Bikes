using Domain.Models;
using MediatR;

namespace Application.Promotions.Queries.GetPromotions
{
    public class GetPromotionsQueryHandler : IRequestHandler<GetPromotionsQuery,IEnumerable<PromoPackage>>
    {
        private readonly IPromotionRepository _promotionRepository;

        public GetPromotionsQueryHandler(IPromotionRepository promotionRepository) { _promotionRepository = promotionRepository; }

        public Task<IEnumerable<PromoPackage>> Handle(GetPromotionsQuery request, CancellationToken cancellationToken)
        {
            var result = _promotionRepository.GetPromotions();
            return Task.FromResult(result);
        }
    }
}
