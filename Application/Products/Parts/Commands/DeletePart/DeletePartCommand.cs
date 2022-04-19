using Domain.Products;
using MediatR;


namespace Application.Products.Parts.Commands.DeletePartCommand
{
    public class DeletePartCommand : IRequest<Part>
    {
        public int Id { get; set; }
    }
}
