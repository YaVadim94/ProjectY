using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ProjectY.Backend.Application.Logic.Models;
using Serilog;

namespace ProjectY.Backend.Web.Api.Middleware
{
    /// <summary>
    /// Обработчик исключений.
    /// </summary>
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        /// <summary>
        /// Middleware для глобального перехвата ошибок.
        /// </summary>
        public ExceptionHandler(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
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

                await context.Response.WriteAsync(new ErrorDetails
                {
                    Name = typeof(Exception).Name,
                    StatusCode = context.Response.StatusCode,
                    Message = ex.Message
                }.ToString(), Encoding.UTF8);
            }
        }
    }
}
