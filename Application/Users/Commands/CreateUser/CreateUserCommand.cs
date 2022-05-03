using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Domain.Models;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Domain.Models.User>
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
