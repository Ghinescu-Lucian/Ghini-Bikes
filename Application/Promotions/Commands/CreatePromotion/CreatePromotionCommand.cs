using Domain.Models;
using MediatR;

namespace Application.Promotions.Commands.CreatePromotion
{
    public class CreatePromotionCommand : IRequest<PromoPackage>
    {
        public string Name { get; set; }
        public List<PromoItem> Items { get; set; }

        public string Image { get; set; }
    }
}
