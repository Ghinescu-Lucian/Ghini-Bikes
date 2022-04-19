using Application.Users.Commands.CreateUser;
using Application.Users.Commands.DeleteUser;
using Application.Users.Commands.UpdateUser;
using Application.Users.Queries.GetUserByID;
using Application.Users.Queries.GetUsersList;
using AutoMapper;
using Domain.Users;
using Ghini_Bikes.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UserController(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto usr)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            usr.Password = Encrypt.EncryptText(usr.Password);
            var command = _mapper.Map<CreateUserCommand>(usr);
            var created = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetUserByID), new { Id = created.Id }, usr);
        }
        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetUserByID(int userId)
        {
            var query = new GetUserByIDQuery { UserId = userId };
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound(result);
            return Ok(result);

        }

        [HttpDelete]
        [Route("{userId}")]
      public async Task<IActionResult> DeleteUser(int userId)
        {
            var command = new DeleteUserCommand { UserId = userId };
            var result = await _mediator.Send(command);
            if (result == null)
                return NotFound(result);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var query = new GetUsersListQuery();
            var result = await _mediator.Send(query);
            return Ok(result);

        }

        [HttpPut]
        [Route("{userId}")]
        public async Task<IActionResult> UpdateUser(int userId, UserDto update)
        {
            var user = _mapper.Map<NormalUser>(update);
            user.Password = Encrypt.EncryptText(user.Password);
            var commnad = new UpdateUserCommand
            {
                UserId = userId,
                Email = user.Email,
                Password = user.Password,
                Username = user.Username,
            };
            var result = await _mediator.Send(commnad);
            if (result == null)
                return NotFound();
            return NoContent();
        }
    }
}
