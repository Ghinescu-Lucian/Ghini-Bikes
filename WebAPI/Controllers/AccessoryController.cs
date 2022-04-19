using Application.Products.Accessories.Commands.CreateAccessoryCommand;
using Application.Products.Accessories.Commands.DeleteAccessoryCommand;
using Application.Products.Accessories.Commands.UpdateAccessoryCommand;
using Application.Products.Accessories.Queries.GetAccessoryById;
using Application.Products.Accessories.Queries.GetAllAccessories;
using AutoMapper;
using Domain.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public AccessoryController(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccessory(AccessoryDto acc)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = _mapper.Map<CreateAccessoryCommand>(acc);
            var created = await _mediator.Send(command);

            //   return Ok(created);
            return CreatedAtAction(nameof(GetAccessoryByID), new { accessoryId = created.ProductId }, acc);
        }
        [HttpGet]
        [Route("{accessoryId}")]
        public async Task<IActionResult> GetAccessoryByID(int accessoryId)
        {
            var query = new GetAccessoryByIdQuery { Id = accessoryId };
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound(result);
            return Ok(result);

        }

        [HttpDelete]
        [Route("{accessoryId}")]
       public async Task<IActionResult> DeleteAccessory(int accessoryId)
        {
            var command = new DeleteAccessoryCommand { Id = accessoryId };
            var result = await _mediator.Send(command);
            if (result == null)
                return NotFound(result);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccessories()
        {
            var query = new GetAllAccessoriesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        [HttpPut]
        [Route("{accessoryId}")]
        public async Task<IActionResult> UpdateAccessory(int accessoryId, AccessoryDto update)
        {
            var acc = _mapper.Map<Accessory>(update);
            var commnad = new UpdateAccessoryCommand
            {
                Id = accessoryId,
                Manufacturer = acc.Manufacturer,
                Model = acc.Model,
                Description = acc.Description,
                Images = acc.Images,
                Price = acc.Price,
                Year = acc.Year,
                Quantity = acc.Quantity
                
            };
            var result = await _mediator.Send(commnad);
            if (result == null)
                return NotFound();
            return NoContent();
        }
    }
}
