using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Dtos
{
   
    public class PromotionDto
    {
        public string Name { get; set; }

     
        public List<int> ItemsId { get; set; }
        public List<double> ItemsDiscount { get; set; }

        public List<int> ItemsCategory { get; set; }

        public List<int> ItemsQuantity { get; set; }

        public IFormFile Image { get; set; }
    }
}
