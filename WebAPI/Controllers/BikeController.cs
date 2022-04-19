using Application.Products.Bikes.Commands.CreateBikeCommand;
using Application.Products.Bikes.Commands.DeleteBikeCommand;
using Application.Products.Bikes.Commands.UpdateBikeCommand;
using Application.Products.Bikes.Queries.GetAllBikes;
using Application.Products.Bikes.Queries.GetBikeById;
using AutoMapper;
using Domain.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public BikeController(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBike(BikeDto bike)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = _mapper.Map<CreateBikeCommand>(bike);
            var created = await _mediator.Send(command);

         //   return Ok(created);
            return CreatedAtAction(nameof(GetBikeByID),new { bikeId = created.ProductId },  bike);
        }
        [HttpGet]
        [Route("{bikeId}")]
        public async Task<IActionResult> GetBikeByID(int bikeId)
        {
            var query = new GetBikeByIdQuery { Id = bikeId };
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound(result);
            return Ok(result);

        }

        [HttpDelete]
        [Route("{bikeId}")]
        public async Task<IActionResult> DeleteBike(int bikeId)
        {
            var command = new DeleteBikeCommand { Id = bikeId };
            var result = await _mediator.Send(command);
            if (result == null)
                return NotFound(result);
            return NoContent();
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllBikes()
        {
            var query = new GetAllBikesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        [HttpPut]
        [Route("{bikeId}")]
        public async Task<IActionResult> UpdateBike(int bikeId, BikeDto update)
        {
            var bike = _mapper.Map<Bike>(update);

            var commnad = new UpdateBikeCommand
            {
                Id = bikeId,
                Manufacturer = bike.Manufacturer,
                Model = bike.Model,
                Description = bike.Description,
                Images = bike.Images,
                Price = bike.Price,
                WarrantyMonths=bike.WarrantyMonths,
                Weigth=bike.Weigth,
                Year=bike.Year,
            };

            var result = await _mediator.Send(commnad);

            if (result == null)
                return NotFound();
            return NoContent();
        }

    }
}
