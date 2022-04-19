using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Domain.Models.User>
    {
        private readonly IUserRepository _repository;

        public UpdateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Models.User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new Domain.Models.User()
            {
                Email = request.Email,
                Username = request.Username,
                Password = request.Password
            };

            _repository.UpdateUser(request.UserId,user);

            return user;

        }
    }
}
