using Domain.Bikes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Bikes.Commands.DeleteBikeCommand
{
    public class DeleteBikeCommand:IRequest<Accessory>
    {
        public string Manufacturer { get; set; }   
        public string Model {get; set; }
        public int Year { get; set; }
    }
}
