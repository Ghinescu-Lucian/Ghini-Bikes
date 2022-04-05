using Domain.Products;
using MediatR;

namespace Application.Products.Parts.Queries.GetAllParts
{
    public class GetAllPartsQuery : IRequest<IEnumerable<Part>>
    {
    }
}
