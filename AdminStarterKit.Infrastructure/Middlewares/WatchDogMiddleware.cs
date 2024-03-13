using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminStarterKit.Infrastructure.Middlewares
{
    public class WatchDogMiddleware
    {
        private readonly RequestDelegate _next;

        public WatchDogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);
        }
    }

    public static class WatchDogMiddlewareExtensions
    {
        public static IApplicationBuilder UseWatchDogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<WatchDogMiddleware>();
        }
    }

}
