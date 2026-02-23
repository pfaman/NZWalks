using System.Net;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace NZWalks.API.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly ILogger<GlobalExceptionMiddleware> logger;
        private readonly RequestDelegate next;

        public GlobalExceptionMiddleware(
            ILogger<GlobalExceptionMiddleware> logger,
            RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();

                // Log the exception
                logger.LogError(ex, "{ErrorId} : {Message}", errorId, ex.Message);

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errorId,
                    Message = "Something went wrong. We are looking into it."
                };

                await context.Response.WriteAsJsonAsync(error);
            }
        }
    }
}