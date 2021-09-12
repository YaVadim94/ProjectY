using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ProjectY.Backend.Shared.BaseExceptions;
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
            catch (ValidationException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                await context.Response.WriteAsync(JsonConvert.SerializeObject(ex.Errors.Select(error =>
                    new ErrorDetailsContract { Name = ex.Name, Message = error.Message }).ToList()), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;

                await context.Response.WriteAsync(new ErrorDetailsContract
                {
                    Name = ex.GetType().Name, Message = ex.Message // TODO: придумать кастомный месседж
                }.ToString(), Encoding.UTF8);
            }
        }
    }
}
