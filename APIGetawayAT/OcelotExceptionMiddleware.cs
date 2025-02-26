using System;
using System.Net;
using System.Text.Json;

namespace APIGetawayAT
{
    public class OcelotExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<OcelotExceptionMiddleware> _logger;

        public OcelotExceptionMiddleware(RequestDelegate next, ILogger<OcelotExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request through Ocelot.");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var response = new
            {
                StatusCode = (int)statusCode,
                Message = "API Gateway encountered an error.",
                Error = exception.GetType().Name
            };

            var result = JsonSerializer.Serialize(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(result);
        }
    }
}
