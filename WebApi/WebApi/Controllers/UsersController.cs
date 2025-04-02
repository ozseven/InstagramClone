using Common.Models.RequestModels.Create;
using Common.Models.RequestModels.Delete;
using Common.Models.RequestModels.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdateUserPasswordCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(DeleteUserCommand deleteUserCommand)
        {
            var result = await _mediator.Send(deleteUserCommand);
            return Ok(result);
        }
    }
} 