using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // Sonraki middleware'e geç
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message); // Loglama
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exception switch
            {
                ArgumentNullException => StatusCodes.Status400BadRequest,
                KeyNotFoundException => StatusCodes.Status404NotFound,
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };

            var response = _env.IsDevelopment()
                ? new
                {
                    status = context.Response.StatusCode,
                    message = exception.Message,
                    stackTrace = exception.StackTrace
                }
                : new
                {
                    status = context.Response.StatusCode,
                    message = "Bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.",
                    stackTrace = (string)null
                };

            var json = JsonConvert.SerializeObject(response);
            return context.Response.WriteAsync(json);
        }
    }

}