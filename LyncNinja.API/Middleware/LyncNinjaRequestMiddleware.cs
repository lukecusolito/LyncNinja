using LyncNinja.Domain.Enumerations;
using LyncNinja.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Threading.Tasks;

namespace LyncNinja.API.Middleware
{
    public class LyncNinjaRequestMiddleware
    {
        #region Fields
        private readonly RequestDelegate _next;
        private readonly ILogger<LyncNinjaRequestMiddleware> _logger;
        #endregion

        #region Constructor
        public LyncNinjaRequestMiddleware(RequestDelegate next, ILogger<LyncNinjaRequestMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        #endregion

        #region Public Methods
        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Path.StartsWithSegments(new PathString("/api")))
            {
                await _next.Invoke(context);
                return;
            }
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                await HandleExceptionAsync(context, ex);
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Formats exceptions and generates an error response
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Override local settings, middleware unaffected by global configuration
            var jsonSettings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };

            var errorCode = ErrorCode.UNEXPECTED_ERROR;
            Enum.TryParse(exception.Message, out errorCode);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorResponse(errorCode), jsonSettings));
        }
        #endregion
    }
}
