using Domain.Models;

namespace WebAPI.Dtos
{
    public class BikeDto
    {
        public int ProductId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public List<Image> Images { get; set; }
        public int Quantity { get; set; }
        public int Category { get; set; }
        public int WarrantyMonths { get; set; }
        public string Specification { get; set; }
        public double Weigth { get; set; }

    }
}
