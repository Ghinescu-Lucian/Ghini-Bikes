using Domain.Models;
using MediatR;

namespace Application.Promotions.Commands.UpdatePromotion
{
    public class UpdatePromotionCommand : IRequest<PromoPackage>
    {
        public int Id { get; set; }
        public PromoPackage Package { get; set; }
    }
}
