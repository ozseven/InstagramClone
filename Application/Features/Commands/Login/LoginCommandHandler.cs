using Application.Interfaces.Repositories;
using Common.Infrastructure.ExistsDatabase;
using Common.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Features.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, User>
    {
        private readonly IUserReadRepository _userReadRepository;

        public LoginCommandHandler(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;
        }

        public async Task<User> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userReadRepository.GetSingleAsync(u => u.UserName == request.UserName);
            if (user == null)
            {
                throw new DatabaseExistingValueException("Kullanıcı bulunamadı.");
            }

            // TODO: Implement proper password hashing and verification
            if (user.Password != request.Password)
            {
                throw new DatabaseExistingValueException("Geçersiz şifre.");
            }

            return user;
        }
    }
} 