using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using SCHESS.Infrastructure.Exceptions;
using SCHESS.Infrastructure.Helpers;
using System.Text.Json;

namespace SCHESS.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly log4net.ILog _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        /// <param name="loggerFactory"></param>
        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.writeRequestLogs();
                await _next(context);
            }
            catch (Exception ex)
            {
                LogUtil.Error(_logger, new LogRequest()
                {
                    ControllerName = string.Empty,
                    ActionName = string.Empty,
                    ApiUrl = string.Empty,
                    Message = ex.Message,
                    DeviceInfo = context.Request.Headers["User-Agent"],
                    IpAddress = context.Connection != null &&
                    context.Connection.RemoteIpAddress != null ?
                    context.Connection.RemoteIpAddress.ToString() : string.Empty,
                    HostName = context.Request.Host.Value,
                    Method = context.Request.Method.ToString(),
                    Path = context.Request.Path,
                });

                await this.handleExceptionMiddleware(context, ex);
            }
        }

        private async Task writeRequestLogs()
        {
            // TODO Write request logs
            await Task.CompletedTask;
        }

        private async Task handleExceptionMiddleware(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            ProblemDetails problemDetail;

            if (exception is UnauthorizedAccessException)
            {
                problemDetail = new ProblemDetails
                {
                    Status = StatusCodes.Status401Unauthorized,
                    Title = "Unauthorized 401",
                    Detail = exception.Message
                };
            }
            else if (exception is NotFoundException)
            {
                problemDetail = new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Not Found 404",
                    Detail = exception.Message
                };
            }
            else if (exception is BadHttpRequestException)
            {
                problemDetail = new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Bad Request 400",
                    Detail = exception.Message
                };
            }
            else
            {
                // Default case for other exceptions (500 Internal Server Error)
                problemDetail = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Internal Server Error 500",
                    Detail = exception.Message
                };
            }

            context.Response.StatusCode = (int)problemDetail.Status;

            var result = JsonSerializer.Serialize(problemDetail);
            await context.Response.WriteAsync(result);
        }
    }
}
