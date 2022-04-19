using Domain.Models;

namespace WebAPI.Dtos
{
    public class PromotionDto
    {
        public string Name { get; set; }
        public List<PromoItem> Items { get; set; }
    }
}
