using Application.Users.Commands.CreateUser;
using Application.Users.Commands.DeleteUser;
using Application.Users.Commands.UpdateUser;
using Application.Users.Queries.GetUserByID;
using Application.Users.Queries.GetUserByUsername;
using Application.Users.Queries.GetUsersList;
using AutoMapper;
using Domain.Models;
using Domain.Users;
using Ghini_Bikes.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using WebAPI.Dtos;
using WebAPI.Settings;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;
        public UserController(IMediator mediator, IMapper mapper, IOptionsSnapshot<JwtSettings> jwtSettings)
        {
            _mapper = mapper;
            _mediator = mediator;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost]
        [Route("{user.Id}")]
        public async Task<IActionResult> Login(UserDto user)
        {
            if (user != null)
            {
                var userDb = await _mediator.Send(new GetUserByUsernameQuery { Username = user.Username });
                if (userDb != null)
                {
                   

                    var password = Encrypt.EncryptText(user.Password);
                    if (string.Equals(password, userDb.Password))
                    {
                        return Ok("{\n \"token\": \""+GenerateJwt(userDb, userDb.Role)+"\"\n}");
                    }
                    else return BadRequest("Wrong username or password!");
                }
                else return BadRequest("Wrong username!");
            }
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto usr)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            // identity, => create user command 
            //  usr.Password = Encrypt.EncryptText(usr.Password);
            usr.Role = "Client";
            var command = _mapper.Map<CreateUserCommand>(usr);
            var created = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetUserByID), new { userId = created.Id }, usr);
        }
        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetUserByID(int userId)
        {
            var query = new GetUserByUsernmaeQuery { UserId = userId };
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
        private string GenerateJwt(User user, string role)
        {
            var claims = new List<Claim>
                   {
                        new Claim(ClaimTypes.NameIdentifier,user.Username),
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim(ClaimTypes.Role, role)
                    };

            var token = new JwtSecurityToken
            (
                issuer: _jwtSettings.Issuer,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(_jwtSettings.ExpirationInDays),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
                    SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
