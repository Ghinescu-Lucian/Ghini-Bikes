using Application.Promotions.Commands.CreatePromotion;
using Application.Promotions.Commands.DeletePromotion;
using Application.Promotions.Commands.UpdatePromotion;
using Application.Promotions.Queries.GetPromotionById;
using Application.Promotions.Queries.GetPromotions;
using AutoMapper;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public PromotionController(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePromotion(PromotionDto promo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var command = _mapper.Map<CreatePromotionCommand>(promo);
            var created = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetPromotionById), new { promoId = created.Id }, promo);
        }
        [HttpGet]
        [Route("{promoId}")]
        public async Task<IActionResult> GetPromotionById(int promoId)
        {
            var query = new GetPromotionByIdQuery { Id = promoId };
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound(result);
            return Ok(result);

        }

        [HttpDelete]
        [Route("{promoId}")]
        public async Task<IActionResult> DeletePromotion(int promoId)
        {
            var command = new DeletePromotionCommand { Id = promoId };
            var result = await _mediator.Send(command);
            if (result == null)
                return NotFound(result);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPromotions()
        {
            var query = new GetPromotionsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        [HttpPut]
        [Route("{promoId}")]
        public async Task<IActionResult> UpdatePromotion(int promoId, PromotionDto update)
        {
            var package = _mapper.Map<PromoPackage>(update);
            var commnad = new UpdatePromotionCommand
            {
                Id = promoId,
                Package = package
            };
            var result = await _mediator.Send(commnad);
            if (result == null)
                return NotFound();
            return NoContent();
        }
    }
}
