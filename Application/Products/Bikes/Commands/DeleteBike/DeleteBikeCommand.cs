using Domain.Bikes;
using Domain.Products;
using MediatR;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Bikes.Commands.DeleteBikeCommand
{
    public class DeleteBikeCommand:IRequest<Bike>
    {
        public int Id { get; set; } 
    }
}
