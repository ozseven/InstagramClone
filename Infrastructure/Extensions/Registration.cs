using Application.Interfaces.Repositories;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructureRegistration(IServiceCollection services,IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(conf =>
            {
                var connStr = configuration.GetConnectionString("DefaultConnection");
                conf.UseSqlServer(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
                conf.EnableSensitiveDataLogging();
            });

            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<IStoryReadRepository, StoryReadRepository>();
            services.AddScoped<IStoryWriteRepository, StoryWriteRepository>();
            services.AddScoped<IStoryVoteReadRepository, StoryVoteReadRepository>();
            services.AddScoped<IStoryVoteWriteRepository, StoryVoteWriteRepository>();
            services.AddScoped<IPostReadRepository, PostReadRepository>();
            services.AddScoped<IPostWriteRepository, PostWriteRepository>();
            services.AddScoped<IPostVoteReadRepository, PostVoteReadRepository>();
            services.AddScoped<IPostVoteWriteRepository, PostVoteWriteRepository>();
            services.AddScoped<IFriendshipReadRepository, FriendshipReadRepository>();
            services.AddScoped<IFriendshipWriteRepository, FriendshipWriteRepository>();
            services.AddScoped<ICommentReadRepository, CommentReadRepository>();
            services.AddScoped<ICommentWriteRepository, CommentWriteRepository>();
            services.AddScoped<ICommentVoteReadRepository, CommentVoteReadRepository>();
            services.AddScoped<ICommentVoteWriteRepository, CommentVoteWriteRepository>();

            return services;
        }
    }
}
