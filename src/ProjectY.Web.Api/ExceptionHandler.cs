using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProjectY.Backend.Web.Api
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
                Console.WriteLine(ex.Message);
            }
        }
    }
}
