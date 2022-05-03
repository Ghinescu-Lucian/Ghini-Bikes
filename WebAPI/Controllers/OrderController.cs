using Application;
using Application.Orders.Commands.CreateOrderCommand;
using Application.Orders.Commands.DeleteOrderCommand;
using Application.Orders.Commands.UpdateOrderCommand;
using Application.Orders.Queries.GetAllOrders;
using Application.Orders.Queries.GetOrderById;
using Application.Products.Accessories.Queries.GetAccessoryById;
using Application.Products.Bikes.Queries.GetBikeById;
using Application.Products.Parts.Queries.GetPartById;
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
        /// sa mut intr-o comanda
        public async Task<IActionResult> CreateOrder(OrderDto order)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            List<OrderItem> items = new List<OrderItem>();
            foreach (OrderItemDto item in order.Items)
            {
                if (item.Category <= 3)
                {
                    var bike = await _mediator.Send(new GetBikeByIdQuery { Id = item.ProductId });
                    var orderItem = new OrderItem { Discount = item.Discount, _Product = bike, Quantity = item.Quantity };
                    items.Add(orderItem);
                }
                else if (item.Category == 4)
                {
                    var part = await _mediator.Send(new GetPartByIdQuery { Id = item.ProductId });
                    var orderItem = new OrderItem { Discount = item.Discount, _Product = part, Quantity = item.Quantity };
                    items.Add(orderItem);
                }
                else if (item.Category == 5)
                {
                    var accessory = await _mediator.Send(new GetAccessoryByIdQuery { Id = item.ProductId });
                    var orderItem = new OrderItem { Discount = item.Discount, _Product = accessory, Quantity = item.Quantity };
                    items.Add(orderItem);
                }
            }
            var command = _mapper.Map<CreateOrderCommand>(order);
            command.Items = items;
            var created = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetOrderByID), new { orderId = created.Id }, order);
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
        public async Task<IActionResult> DeleteOrder(int orderId)
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
        public async Task<IActionResult> UpdateOrder(int orderId, OrderDto update)
        {
            var order = _mapper.Map<Order>(update);
            var commnad = new UpdateOrderCommand
            {
                Id = orderId,
                Items = order.Items,
                Date = order.Date,
                UserId = order.UserId,
                TelephoneNr = order.TelephoneNr,
                Address = order.Address,
                Payment = (Domain.Enums.Payment)order.Pay,
                Status = (Domain.Enums.Status)order.Status,
                ShippingMethod = "Courier"
            };
            var result = await _mediator.Send(commnad);
            if (result == null)
                return NotFound();
            return NoContent();
        }
    }
}
