﻿using Domain.Models;
using Domain.Products;
using MediatR;

namespace Application.Products.Accessories.Commands.CreateAccessoryCommand
{
    public class CreateAccessoryCommand:IRequest<Accessory>
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public List<Image> Images { get; set; }
    }
}
