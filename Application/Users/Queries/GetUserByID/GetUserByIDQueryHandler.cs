using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserByID
{
    public class GetUserByIDQueryHandler : IRequestHandler<GetUserByUsernmaeQuery, User>
    { 
        private readonly IUserRepository _repository;

        public GetUserByIDQueryHandler(IUserRepository userRepository)
        {
            _repository = userRepository;
        }


        Task<User> IRequestHandler<GetUserByUsernmaeQuery, User>.Handle(GetUserByUsernmaeQuery request, CancellationToken cancellationToken)
        {
            var result = _repository.GetUserById(request.UserId);
            return Task.FromResult(result);
        }
    }
}
