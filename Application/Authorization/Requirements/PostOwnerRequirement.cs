using Microsoft.AspNetCore.Authorization;

namespace Application.Authorization.Requirements
{
    /// <summary>
    /// Post sahibi olma gerekliliğini kontrol eden sınıf
    /// </summary>
    public class PostOwnerRequirement : IAuthorizationRequirement
    {
        public Guid PostId { get; }
        public Guid UserId { get; }

        public PostOwnerRequirement(Guid postId, Guid userId)
        {
            PostId = postId;
            UserId = userId;
        }
    }
} 