using Microsoft.AspNetCore.Builder;

namespace eCademiaApp.Core.Extensions
{
    // To make exception middleware use in program.cs
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
