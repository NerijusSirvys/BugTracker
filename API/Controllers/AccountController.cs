using API.Routes;
using Application.Commands;
using Application.Queries;
using Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(UserRoutes.GetAllUsers)]
        public async Task<IActionResult> GetUsersAsync()
        {
            var users = await _mediator.Send(new GetAllUsersQuery.Query());

            if(users == null) return NotFound();

            return Ok(users);
        }

        [HttpGet(UserRoutes.GetUser)]
        public async Task<IActionResult> GetUserAsync(Guid id)
        {
            var user = await _mediator.Send(new GetUserQuery.Query { Id = id });

            if(user is null) return NotFound();

            return Ok(user);
        }

        [HttpPost(UserRoutes.CreateUser)]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserRequest request)
        {
            await _mediator.Send(new CreateUserCommand.Command { User = request });

            return NoContent();
        }

        [HttpDelete(UserRoutes.DeleteUser)]
        public async Task<IActionResult> DeleteUserAsync(Guid id)
        {
            await _mediator.Send(new DeleteUserCommand.Command { Id = id });

            return NoContent();
        }
    }
}
