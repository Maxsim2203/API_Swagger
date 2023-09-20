using DemoMediatR.Models;
using MediatR;

namespace DemoMediatR.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
    }
}
