using Domain.Models;
using MediatR;

namespace Application.Promotions.Queries.GetPromotionById
{
    public class GetPromotionByIdQueryHandler : IRequestHandler<GetPromotionByIdQuery,PromoPackage>
    {
        private readonly IPromotionRepository _promotionRepository;

        public GetPromotionByIdQueryHandler(IPromotionRepository promotionRepository) { _promotionRepository = promotionRepository; }

        public Task<PromoPackage> Handle(GetPromotionByIdQuery request, CancellationToken cancellationToken)
        {
           var result = _promotionRepository.GetPromotionById(request.Id);
            return Task.FromResult(result);
        }
    }
}
