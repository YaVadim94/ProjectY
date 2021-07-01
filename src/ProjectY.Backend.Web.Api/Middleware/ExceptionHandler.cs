using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ProjectY.Backend.Web.Api.Middleware
{
    /// <summary>
    /// Обработчик исключений.
    /// </summary>
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Middleware для глобального перехвата ошибок.
        /// </summary>
        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Выполнение кода middleware.
        /// </summary>
        public async Task Invoke(HttpContext context)
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

        /// <summary>
        /// Метод для обработки исключений.
        /// </summary>
        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var result = JsonConvert.SerializeObject(new { Type = typeof(Exception).Name, Message = ex.Message });

            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            /* TODO: При создании кастомных типов исключений, добавлять их сюда
            //if (ex is customException) code = HttpStatusCode.NotFound;
            //else if (ex is customException) code = HttpStatusCode.Unauthorized;
            //else if (ex is customException) code = HttpStatusCode.BadRequest;
            */

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result, Encoding.UTF8);
        }
    }
}
