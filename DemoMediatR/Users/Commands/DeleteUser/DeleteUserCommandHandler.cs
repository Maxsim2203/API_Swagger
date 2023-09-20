using DemoMediatR.Interfaces;
using DemoMediatR.Models;
using MediatR;

namespace DemoMediatR.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly IRepository<User> _repository;

        public DeleteUserCommandHandler(IRepository<User> repository) => _repository = repository;

        public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _repository.GetById(request.Id);

            if (user == null || user.Id != request.Id)
            {
                throw new Exception("User not found");
            }

            try
            {
                _repository.Delete(user);
                await _repository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return user.Id;
        }
    }
}
