using Domain.Products;
using MediatR;


namespace Application.Products.Bikes.Commands.UpdateBikeCommand
{
    public class UpdateBikeCommandHandler : IRequestHandler<UpdateBikeCommand, Bike>
    {
        private readonly IBikeRepository _repository;

        public UpdateBikeCommandHandler(IBikeRepository repository)
        {
            _repository = repository;
        }


        public async Task<Bike> Handle(UpdateBikeCommand request, CancellationToken cancellationToken)
        {
            var bike = new Bike()
            {
                Manufacturer = request.Manufacturer,
                Model = request.Model,
                Year = request.Year,
                Price=request.Price,
                Weigth = request.Weigth,
                WarrantyMonths = request.WarrantyMonths,
                Description = request.Description,
                Images = request.Images,

            };

            _repository.UpdateBike(request.Id,bike);

            return bike;
        }
    }
}
