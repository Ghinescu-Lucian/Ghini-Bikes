using Domain.Models;
using MediatR;

namespace Application.Promotions.Queries.GetPromotionById
{
    public class GetPromotionByIdQuery : IRequest<PromoPackage>
    {
        public int Id { get; set; }
    }
}
