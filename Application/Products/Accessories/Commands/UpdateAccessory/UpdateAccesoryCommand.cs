﻿using Domain.Bikes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Accessories.Commands.UpdateAccessoryCommand
{
    public class UpdateAccessoryCommand : IRequest<Accessory>
    {
        public int Id { get; set; } 
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public string Model { get; set; }
    }
}
