using Domain.Products;
using MediatR;

namespace Application.Products.Parts.Queries.GetPartById
{
    public class GetPartByIdQuery : IRequest<Part>
    {
        public int Id { get; set; }
    }
}
