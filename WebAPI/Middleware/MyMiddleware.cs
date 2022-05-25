using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebAPI.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;

        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {

            // Check if request body is empty and it's a multipart request
            if ((context.Request.ContentLength == null || context.Request.ContentLength == 0)
                && context.Request.ContentType != null
                && context.Request.ContentType.ToUpper().StartsWith("MULTIPART/"))
            {
                // Set 400 response with a message
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Multipart request body must not be empty.");
            }
            else
            {
                // All other requests continue the way down the pipeline
                await _next(context);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware>();
        }
    }
}
