using DemoMediatR.Interfaces;
using DemoMediatR.Models;
using MediatR;

namespace DemoMediatR.Users.Queries.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdResult>
    {
        private readonly IRepository<User> _repository;

        public GetUserByIdHandler(IRepository<User> repository) => _repository = repository;

        public async Task<GetUserByIdResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            User user = await _repository.GetById(request.Id);

            return new GetUserByIdResult
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                RoleId = user.RoleId
            };
        }
    }
}
