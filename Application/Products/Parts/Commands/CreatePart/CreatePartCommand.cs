using Domain.Models;
using Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Parts.Commands.CreatePartCommand
{
    public class CreatePartCommand : IRequest<Part>
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }

        public List<Image> Images { get; set; }
        public List<CompatibleItem> Bikes { get; set; }
    }
}
