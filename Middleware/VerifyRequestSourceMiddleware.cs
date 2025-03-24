using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace UserBlogAPI.Middleware
{
    public class VerifyRequestSourceMiddleware
    {
        private readonly RequestDelegate _next;

        public VerifyRequestSourceMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var path = context.Request.Path.Value?.ToLower();
            if (path.Contains("register") || path.Contains("login"))
            {
                if (!context.Request.Headers.TryGetValue("X-Request-Source", out var requestSource) || string.IsNullOrEmpty(requestSource))
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Missing or invalid request source.");
                    return;
                }

                var allowedSources = new List<string> { "MobileApp" };
                if (!allowedSources.Contains(requestSource.ToString()))
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("Unauthorized request source.");
                    return;
                }
            }

            await _next(context);
        }
    }

}
