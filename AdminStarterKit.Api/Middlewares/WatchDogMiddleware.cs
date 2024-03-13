namespace AdminStarterKit.Api.Middlewares
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
            context.Request.EnableBuffering();

            using (var memoryStream = new MemoryStream())
            {
                await context.Request.Body.CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                var requestBody = await new StreamReader(memoryStream).ReadToEndAsync();
            }
            context.Request.Body.Position = 0;

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
