using System;
using System.Net;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Api.Common {
    public class CustomExceptionHandlerMiddleware {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        /// <summary>
        /// CustomExceptionHandlerMiddleware
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public CustomExceptionHandlerMiddleware (RequestDelegate next, ILogger<CustomExceptionHandlerMiddleware> logger) {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// InvokeAsync
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task InvokeAsync (HttpContext httpContext) {
            try {
                await _next (httpContext);
            } catch (Exception ex) {
                _logger.LogTrace ($"Something went wrong: {ex.Source} {ex.Message}");
                await HandleExceptionAsync (httpContext, _logger, ex);
            }
        }

        private static Task HandleExceptionAsync (HttpContext context, ILogger logger, Exception exception) {
            var code = HttpStatusCode.InternalServerError;

            var result = string.Empty;
            switch (exception) {
                case BadRequestException badRequestException:
                    code = HttpStatusCode.BadRequest;
                    result = badRequestException.Message;
                    break;
                case System.ArgumentNullException badRequestException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject (new { Error = badRequestException.Message });
                    break;
                case System.NullReferenceException badRequestException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject (new { Error = badRequestException.Message });
                    break;
                case System.ArgumentException badRequestException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject (new { Error = badRequestException.Message });
                    break;
                case NotFoundException _:
                    code = HttpStatusCode.NotFound;
                    result = JsonConvert.SerializeObject (new { Error = exception.Message });
                    break;
            }

            context.Response.ContentType = Constant.HeaderJson;
            context.Response.StatusCode = (int) code;

            if (string.IsNullOrEmpty (result)) {
                result = JsonConvert.SerializeObject (new { error = "Internal Server Error" });
                logger.LogError ($"Internal Server Error : {exception.Source} {exception.Message}");
            }
            return context.Response.WriteAsync (result);
        }

    }

    /// <summary>
    /// CustomExceptionHandlerMiddlewareExtensions
    /// </summary>
    public static class CustomExceptionHandlerMiddlewareExtensions {
        /// <summary>
        /// UseCustomExceptionHandler
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseCustomExceptionHandler (this IApplicationBuilder builder) {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware> ();
        }
    }
}