﻿namespace WebAPI.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Quantity { get; set; }
    }
}
