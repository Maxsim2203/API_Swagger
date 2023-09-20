using DemoMediatR.Models;
using MediatR;

namespace DemoMediatR.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<User>
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
