using Domain.Bikes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Accessories.Commands.DeleteAccessoryCommand
{
    public class DeleteAccessoryCommand : IRequest<Accessory>
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
       
    }
}
