using GoalSystems.InventoryManager.Infrastructure.CrossCutting.Services.Logging;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace GoalSystems.InventoryManager.Api.Model.Error
{
    /// <summary>
    /// Gestión de errores no controlados por la aplicación
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            LoggingService.LogException(ex);

            int code = (int)HttpStatusCode.InternalServerError; // 500

            if (ex is WebException)
            {
                WebException e = (WebException)ex;
                var response = e.Response as HttpWebResponse;
                if (response != null)
                {
                    code = (int)response.StatusCode;
                }
            }

            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;
            return context.Response.WriteAsync(result);
        }
    }
}
