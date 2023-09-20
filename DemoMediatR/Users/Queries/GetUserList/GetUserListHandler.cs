using DemoMediatR.Interfaces;
using DemoMediatR.Models;
using MediatR;

namespace DemoMediatR.Users.Queries.GetUserList
{
    public class GetUserListHandler : IRequestHandler<GetUserListQuery, IEnumerable<User>>
    {
        private readonly IRepository<User> _repository;

        public GetUserListHandler(IRepository<User> repository) => _repository = repository;

        public async Task<IEnumerable<User>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
