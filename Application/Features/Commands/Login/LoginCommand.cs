using Domain;
using MediatR;

namespace Application.Features.Commands.Login
{
    public class LoginCommand : IRequest<User>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
} 