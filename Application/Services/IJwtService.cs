using System.Security.Claims;
using Domain;

namespace Application.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
        ClaimsPrincipal ValidateToken(string token);
    }
} 