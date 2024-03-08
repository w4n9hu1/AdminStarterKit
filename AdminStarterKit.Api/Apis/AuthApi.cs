
using Microsoft.AspNetCore.Http.HttpResults;

namespace AdminStarterKit.Api.Apis
{
    public static class AuthApi
    {
        public static RouteGroupBuilder MapAuthApi(this RouteGroupBuilder builder)
        {
            builder.MapPost("/register", RegisterAsync);
            builder.MapPost("/login", RegisterAsync);
            return builder;
        }

        private static Ok RegisterAsync()
        {
            return TypedResults.Ok();
        }
    }
}
