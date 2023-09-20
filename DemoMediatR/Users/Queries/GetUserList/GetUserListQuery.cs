using DemoMediatR.Models;
using MediatR;

namespace DemoMediatR.Users.Queries.GetUserList
{
    public class GetUserListQuery : IRequest<IEnumerable<User>>
    {
        public int Id { get; set; }
    }
}
