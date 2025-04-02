using Application.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace Application.Authorization.Policies
{
    /// <summary>
    /// Uygulama genelinde kullanılacak authorization policy'lerini tanımlayan sınıf
    /// </summary>
    public static class AuthorizationPolicies
    {
        /// <summary>
        /// Post sahibi olma policy'si
        /// </summary>
        public const string PostOwner = "PostOwner";

        /// <summary>
        /// Admin olma policy'si
        /// </summary>
        public const string Admin = "Admin";

        /// <summary>
        /// Policy'leri yapılandıran extension method
        /// </summary>
        public static void ConfigurePolicies(this AuthorizationOptions options)
        {
            // Post sahibi olma policy'si
            options.AddPolicy(PostOwner, policy =>
                policy.Requirements.Add(new PostOwnerRequirement(Guid.Empty, Guid.Empty)));

            // Admin olma policy'si
            options.AddPolicy(Admin, policy =>
                policy.RequireRole("Admin"));
        }
    }
} 