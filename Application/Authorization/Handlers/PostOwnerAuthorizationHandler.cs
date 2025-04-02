using Application.Authorization.Requirements;
using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Application.Authorization.Handlers
{
    /// <summary>
    /// Post sahibi olma gerekliliğini kontrol eden handler sınıfı
    /// </summary>
    public class PostOwnerAuthorizationHandler : AuthorizationHandler<PostOwnerRequirement>
    {
        private readonly IPostReadRepository _postReadRepository;

        public PostOwnerAuthorizationHandler(IPostReadRepository postReadRepository)
        {
            _postReadRepository = postReadRepository;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            PostOwnerRequirement requirement)
        {
            // Kullanıcının post sahibi olup olmadığını kontrol et
            var post = await _postReadRepository.GetSingleAsync(p => p.Id == requirement.PostId);
            
            if (post != null && post.UserId == requirement.UserId)
            {
                context.Succeed(requirement);
            }
        }
    }
} 