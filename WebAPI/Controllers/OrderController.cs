using Application;
using Application.Orders.Commands.CreateOrderCommand;
using Application.Orders.Commands.DeleteOrderCommand;
using Application.Orders.Commands.UpdateOrderCommand;
using Application.Orders.Queries.GetAllOrders;
using Application.Orders.Queries.GetOrderById;
using Application.Orders.Queries.GetOrdersByUser;
using Application.Products.Accessories.Queries.GetAccessoryById;
using Application.Products.Bikes.Queries.GetBikeById;
using Application.Products.Parts.Queries.GetPartById;
using AutoMapper;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
                var itm = new OrderItem
                {
                    ProductId = item.ProductId,
                    Price = item.Price,
                    Manufacturer = item.Manufacturer,
                    Model = item.Model,
                    Category = item.Category,
                    Discount = item.Discount,
                    Year = item.Year,
                    OrderId = item.OrderId,
                    Quantity = item.Quantity,
                    Image = item.Image,
                    Description = item.Description
                };
                items.Add(itm);
               
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

        [HttpGet]
        [Route("user/{userId}")]
        public async Task<IActionResult> GetOrderByUserID(int userId)
        {
            var query = new GetOrdersByUserQuery { UserId = userId };
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> UpdateOrder(int orderId, UpdateOrderDTO update)
        {
            var order = _mapper.Map<Order>(update);
            var commnad = new UpdateOrderCommand
            {
                Id = orderId,
                Status = (Domain.Enums.Status)order.Status,
                Message = update.Message,
            };
            var result = await _mediator.Send(commnad);
            if (result == null)
                return NotFound();
            return NoContent();
        }
    }
}
