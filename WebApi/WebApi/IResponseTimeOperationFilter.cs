using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApi
{
    public interface IResponseTimeOperationFilter
    {
        void Apply(OpenApiOperation operation, OperationFilterContext context);
    }
}