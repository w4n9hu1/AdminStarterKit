using Microsoft.AspNetCore.Http.HttpResults;

namespace AdminStarterKit.Api.Apis
{
    public static class TaskApi
    {
        public static RouteGroupBuilder MapTaskApi(this RouteGroupBuilder builder)
        {
            builder.MapPost("/", CreateTask);
            return builder;
        }

        private static Ok CreateTask()
        {
            return TypedResults.Ok();
        }
    }
}
