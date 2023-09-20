using DemoMediatR.Models;
using DemoMediatR.Users.Commands.CreateUser;
using DemoMediatR.Users.Commands.DeleteUser;
using DemoMediatR.Users.Commands.UpdateUser;
using DemoMediatR.Users.Queries.GetUserById;
using DemoMediatR.Users.Queries.GetUserList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DemoMediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult> GetUser()
        {
            IEnumerable<User> user = await _mediator.Send(new GetUserListQuery());

            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            GetUserByIdResult result = await _mediator.Send(new GetUserByIdQuery(id));

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(CreateUserCommand command)
        {
            User user = await _mediator.Send(command);

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return NotFound();
            }

            User user = await _mediator.Send(command);

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            DeleteUserCommand command = new DeleteUserCommand
            {
                Id = id
            };

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
