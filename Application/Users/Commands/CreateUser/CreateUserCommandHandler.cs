using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using MediatR;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            /*var user = new User
            {
                Email = request.Email,
            Username = request.Username,
            Password = request.Password
             };
            _repository.CreateUser(user);
            await _repository.SaveChangesAsync();
            return user;*/
            return null;
        }
       
    }
}

