using Domain.Bikes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.Accessories.Queries.GetAllAccessories
{
    public class GetAllAccessoriesQuery : IRequest<IEnumerable<Accessory>>
    {
    }
}
