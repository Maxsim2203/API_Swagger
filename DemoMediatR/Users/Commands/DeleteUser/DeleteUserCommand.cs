using MediatR;

namespace DemoMediatR.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
