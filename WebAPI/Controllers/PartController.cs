using Application.Products.Parts.Commands.CreatePartCommand;
using Application.Products.Parts.Commands.DeletePartCommand;
using Application.Products.Parts.Commands.UpdatePartCommand;
using Application.Products.Parts.Queries.GetAllParts;
using Application.Products.Parts.Queries.GetPartById;
using AutoMapper;
using Domain.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public PartController(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePart(PartDto part)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = _mapper.Map<CreatePartCommand>(part);
            var created = await _mediator.Send(command);

            //   return Ok(created);
            return CreatedAtAction(nameof(GetPartByID), new { partId = created.ProductId }, part);
        }
        [HttpGet]
        [Route("{partId}")]
        public async Task<IActionResult> GetPartByID(int partId)
        {
            var query = new GetPartByIdQuery { Id = partId };
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound(result);
            return Ok(result);

        }

        [HttpDelete]
        [Route("{partId}")]
        public async Task<IActionResult> DeletePart(int partId)
        {
            var command = new DeletePartCommand { Id = partId };
            var result = await _mediator.Send(command);
            if (result == null)
                return NotFound(result);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllParts()
        {
            var query = new GetAllPartsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);

        }

       [HttpPut]
        [Route("{partId}")]
        public async Task<IActionResult> UpdatePart(int partId, PartDto update)
        {
            var part = _mapper.Map<Part>(update);
            var commnad = new UpdatePartCommand
            {
                Id = partId,
                Manufacturer = part.Manufacturer,
                Model = part.Model,
                Description = part.Description,
                Images = part.Images,
                Price = part.Price,
                Year = part.Year,
                Quantity = part.Quantity

            };
            var result = await _mediator.Send(commnad);
            if (result == null)
                return NotFound();
            return NoContent();
        }
    }
}
