using Application.Users.Queries.GetUserByID;
using Domain.Models;
using MediatR;

namespace Application.Users.Queries.GetUserByUsername
{
    public class GetUserByUsernameHandler : IRequestHandler<GetUserByUsernameQuery, User>
    {
        private readonly IUserRepository _repository;

        public GetUserByUsernameHandler(IUserRepository userRepository)
        {
            _repository = userRepository;
        }


        Task<User> IRequestHandler<GetUserByUsernameQuery, User>.Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            var result = _repository.GetUserByUsername(request.Username);
            return Task.FromResult(result);
        }
    }

}
