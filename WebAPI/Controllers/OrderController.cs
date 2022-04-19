using Application.Orders.Commands.CreateOrderCommand;
using Application.Orders.Commands.DeleteOrderCommand;
using Application.Orders.Commands.UpdateOrderCommand;
using Application.Orders.Queries.GetAllOrders;
using Application.Orders.Queries.GetOrderById;
using AutoMapper;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public OrderController(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDto order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var command = _mapper.Map<CreateOrderCommand>(order);
            var created = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetOrderByID), new { orderId = created.Id } );
        }
        [HttpGet]
        [Route("{orderId}")]
        public async Task<IActionResult> GetOrderByID(int orderId)
        {
            var query = new GetOrderByIdQuery { Id = orderId };
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound(result);
            return Ok(result);

        }

        [HttpDelete]
        [Route("{orderId}")]
        public async Task<IActionResult> DeleteUser(int orderId)
        {
            var command = new DeleteOrderCommand { Id = orderId };
            var result = await _mediator.Send(command);
            if (result == null)
                return NotFound(result);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var query = new GetAllOrdersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        [HttpPut]
        [Route("{orderId}")]
        public async Task<IActionResult> UpdateUser(int orderId, UserDto update)
        {
            var order = _mapper.Map<Order>(update);
            var commnad = new UpdateOrderCommand
            {
                Id = orderId,
                Items = order.Items,
                Date = order.Date,
                User = order.User,
                TelephoneNr = order.TelephoneNr,
                Address = order.Address,
                Payment = (Domain.Enums.Payment)order.Pay,
                Status = (Domain.Enums.Status)order.Status,
                ShippingMethod = "Courier"
               /* UserId = userId,
                Email = user.Email,
                Password = user.Password,
                Username = user.Username,*/
            };
            var result = await _mediator.Send(commnad);
            if (result == null)
                return NotFound();
            return NoContent();
        }
    }
}
