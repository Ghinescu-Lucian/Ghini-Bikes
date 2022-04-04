using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserByID
{
    public class GetUserByIDQueryHandler : IRequestHandler<GetUserByIDQuery, User>
    { 
        private readonly IUserRepository _repository;

        public GetUserByIDQueryHandler(IUserRepository userRepository)
        {
            _repository = userRepository;
        }


        Task<User> IRequestHandler<GetUserByIDQuery, User>.Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
        {
            var result = _repository.GetUserById(request.UserId);
            return Task.FromResult(result);
        }
    }
}
