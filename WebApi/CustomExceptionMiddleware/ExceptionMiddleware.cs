using System.Net;
using System.Text.Json;

using BadRequestException = WebApi.Exceptions.BadRequestException;
using KeyNotFoundException = WebApi.Exceptions.KeyNotFoundException;
using NotFoundException = WebApi.Exceptions.NotFoundException;
using NotImplementedException = WebApi.Exceptions.NotImplementedException;
using UnauthorizedAccessException = WebApi.Exceptions.UnauthorizedAccessException;

namespace WebApi.CustomExceptionMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            HttpStatusCode status;

            var stackTrace = ex.StackTrace;

            string message;

            switch (ex)
            {
                case BadRequestException:
                    status = HttpStatusCode.BadRequest;
                    message = ex.Message;
                    break;
                case NotFoundException:
                    status = HttpStatusCode.NotFound;
                    message = ex.Message;
                    break;
                case NotImplementedException:
                    status = HttpStatusCode.NotImplemented;
                    message = ex.Message;
                    break;
                case KeyNotFoundException:
                    status = HttpStatusCode.NotFound;
                    message = ex.Message;
                    break;
                case UnauthorizedAccessException:
                    status = HttpStatusCode.Unauthorized;
                    message = ex.Message;
                    break;
                default:
                    status = HttpStatusCode.InternalServerError;
                    message = ex.Message;
                    break;
            }

            var exceptionResult = JsonSerializer.Serialize(new { error = message, stackTrace });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            return context.Response.WriteAsync(exceptionResult);
        }
    }
}