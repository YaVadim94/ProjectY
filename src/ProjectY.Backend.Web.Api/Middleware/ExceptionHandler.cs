using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ProjectY.Backend.Web.Api.Middleware
{
    /// <summary>
    /// Обработчик исключений
    /// </summary>
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Middleware для глобального перехвата ошибок
        /// </summary>
        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Выполнение кода middleware
        /// </summary>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var message = JsonConvert.SerializeObject(new { Type = typeof(Exception).Name, Message = ex.Message });
                await context.Response.WriteAsync(message, Encoding.UTF8);
            }
        }
    }
}
