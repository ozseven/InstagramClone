using Application.Features.Commands.Create;
using Application.Features.Commands.Delete;
using Application.Features.Commands.Update;
using Application.Mapping;
using Application.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => 
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IJwtService, JwtService>();
            return services;
        }
    }
} 