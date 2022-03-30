using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUsersList
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, IEnumerable<User>>
    {
        private readonly IUserRepository _repository;

        public GetUsersListQueryHandler(IUserRepository userRepository)
        {
            _repository = userRepository;
        }

        public Task<IEnumerable<User>> Handle(GetUsersListQuery request, CancellationToken cancellationToken)
        {
            var result = _repository.GetUsers();
            return Task.FromResult(result);
        }
    }
}
