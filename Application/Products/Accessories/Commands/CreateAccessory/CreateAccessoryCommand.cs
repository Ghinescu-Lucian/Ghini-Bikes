using Domain.Bikes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Accessories.Commands.CreateAccessoryCommand
{
    public class CreateAccessoryCommand:IRequest<Accessory>
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
    }
}
