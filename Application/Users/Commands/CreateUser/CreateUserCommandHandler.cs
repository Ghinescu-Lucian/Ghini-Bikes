using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Users;
using Ghini_Bikes.Services;
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

        public async Task<Domain.Models.User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new Domain.Models.User()
            {
                Email = request.Email,
                Username = request.Username,
                Password = Encrypt.EncryptText(request.Password),
                Role=request.Role
             };

            _repository.CreateUser(user);

            return user;

            //return null;
        }
       
    }
}

