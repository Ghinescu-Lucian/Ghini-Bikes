using Domain.Models;

namespace WebAPI.Dtos
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public string Description { get; set; }

        public int OrderId { get; set; }
        public int Category { get; set; }   
        public double Discount { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string Image { get; set; }
        public int Quantity { get; set; }
    }
}
