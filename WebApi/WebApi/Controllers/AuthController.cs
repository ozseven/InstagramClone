using Application.Features.Commands.Login;
using Application.Services;
using Common.Models.RequestModels.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IJwtService _jwtService;

        public AuthController(IMediator mediator, IJwtService jwtService)
        {
            _mediator = mediator;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserCommand command)
        {
            var userId = await _mediator.Send(command);
            return Ok(new { UserId = userId });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var user = await _mediator.Send(command);
            if (user == null)
            {
                return Unauthorized();
            }

            var token = _jwtService.GenerateToken(user);
            return Ok(new { Token = token });
        }
    }
} 