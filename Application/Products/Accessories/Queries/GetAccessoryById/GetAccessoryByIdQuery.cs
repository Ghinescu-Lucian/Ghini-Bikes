using Domain.Bikes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Accessories.Queries.GetAccessoryById
{
    public class GetAccessoryByIdQuery : IRequest<Accessory>
    {
        public int Id { get; set; }
    }
}
