using BlazorApp1.Shared.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private static ILogger<ExceptionHandlingMiddleware> _loggerFactory;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> Logger)
        {
            _next = next;
            _loggerFactory = Logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (!httpContext.Response.HasStarted)
                {
                    _loggerFactory.LogError(ex, "Request Erro");

                    httpContext.Response.StatusCode = 200;
                    httpContext.Response.ContentType = "application/json";
                    var response = new ServiceResponse<string>();
                    response.SetException(ex);
                    var json = JsonConvert.SerializeObject(response);
                    await httpContext.Response.WriteAsync(json);
                }
            }
        }
    }
}
