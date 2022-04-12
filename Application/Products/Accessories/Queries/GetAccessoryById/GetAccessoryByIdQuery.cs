using Domain.Bikes;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Accessories.Queries.GetAccessoryById
{
    public class GetAccessoryByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
