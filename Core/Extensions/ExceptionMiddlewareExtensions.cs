using Microsoft.AspNetCore.Builder;
 
namespace Core.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigurecustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
