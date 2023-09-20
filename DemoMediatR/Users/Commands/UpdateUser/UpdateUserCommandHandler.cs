using DemoMediatR.Interfaces;
using DemoMediatR.Models;
using MediatR;

namespace DemoMediatR.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IRepository<User> _repository;

        public UpdateUserCommandHandler(IRepository<User> repository) => _repository = repository;

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _repository.GetById(request.Id);

            if (user == null || user.Id != request.Id)
            {
                throw new Exception("User not found");
            }

            try
            {
                user.Name = request.Name;
                user.Email = request.Email;
                user.RoleId = request.RoleId;

                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return user;
        }
    }
}
