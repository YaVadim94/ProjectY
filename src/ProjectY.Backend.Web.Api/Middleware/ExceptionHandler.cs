using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ProjectY.Shared.Contracts;

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
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;

                await context.Response.WriteAsync(new ErrorDetailsContract
                {
                    Name = typeof(Exception).Name,
                    Message = ex.Message
                }.ToString(), Encoding.UTF8);
            }
        }
    }
}
