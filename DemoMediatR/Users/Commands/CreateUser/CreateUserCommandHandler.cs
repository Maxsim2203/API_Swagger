using DemoMediatR.Interfaces;
using DemoMediatR.Models;
using MediatR;

namespace DemoMediatR.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IRepository<User> _repository;

        public CreateUserCommandHandler(IRepository<User> repository) => _repository = repository;

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new User()
            {
                Name = request.Name,
                Email = request.Email,
                RoleId = request.RoleId,
            };

            _repository.Create(user);
            _repository.SaveChangesAsync();

            return user;
        }
    }
}
