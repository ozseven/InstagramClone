using Common.Models.RequestModels.Create.Entities.CreateVoteCommand;
using Common.Models.RequestModels.Delete.DeleteVoteCommand;
using Common.Models.RequestModels.Update.UpdateVoteCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VotesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("post")]
        public async Task<IActionResult> CreatePostVote([FromBody] CreatePostVoteCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("comment")]
        public async Task<IActionResult> CreateCommentVote([FromBody] CreateCommentVoteCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("story")]
        public async Task<IActionResult> CreateStoryVote([FromBody] CreateStoryVoteCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("post")]
        public async Task<IActionResult> UpdatePostVote([FromBody] UpdatePostVoteCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("comment")]
        public async Task<IActionResult> UpdateCommentVote([FromBody] UpdateCommentVoteCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("story")]
        public async Task<IActionResult> UpdateStoryVote([FromBody] UpdateStoryVoteCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("post/{id}")]
        public async Task<IActionResult> DeletePostVote(Guid id)
        {
            var result = await _mediator.Send(new DeletePostVoteCommand { Id = id });
            return Ok(result);
        }

        [HttpDelete("comment/{id}")]
        public async Task<IActionResult> DeleteCommentVote(Guid id)
        {
            var result = await _mediator.Send(new DeleteCommentVoteCommand { Id = id });
            return Ok(result);
        }

        [HttpDelete("story/{id}")]
        public async Task<IActionResult> DeleteStoryVote(Guid id)
        {
            var result = await _mediator.Send(new DeleteStoryVoteCommand { Id = id });
            return Ok(result);
        }
    }
} 