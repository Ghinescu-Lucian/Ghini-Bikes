using Domain.Models;
using MediatR;

namespace Application.Promotions.Queries.GetPromotions
{
    public class GetPromotionsQuery : IRequest<IEnumerable<PromoPackage>>
    {
    }
}
