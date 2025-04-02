using Common.Models.RequestModels.Create.Entities;
using Common.Models.RequestModels.Delete;
using Common.Models.RequestModels.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Authorization.Requirements;
using Application.Authorization.Policies;
using Domain;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreatePostCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Policy = AuthorizationPolicies.PostOwner)]
        public async Task<IActionResult> Update([FromBody] UpdatePostCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(DeletePostCommand deletePostCommand)
        {
            var result = await _mediator.Send(deletePostCommand);
            return Ok(result);
        }
    }
} 