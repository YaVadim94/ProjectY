using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjectY.Backend.Application.Core.Exceptions;
using ProjectY.Backend.Web.Api.Exceptions;

namespace ProjectY.Backend.Web.Api.Filters
{
    /// <summary>
    /// Фильтр для валидации данных.
    /// </summary>
    public class ValidationFilter : IAsyncActionFilter
    {
        /// <summary>
        /// Метод вызываемый после привязки данных к модели и перед самим методом действия.
        /// </summary>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());

                var validationErrors = new List<ValidationError>();

                foreach (var error in errorsInModelState)
                {
                    validationErrors.AddRange(error.Value.Select(subError => new ValidationError
                    {
                        FieldName = error.Key,
                        Message = subError
                    }));
                }

                throw new ContractValidationException(validationErrors.ToArray());
            }

            await next();
        }
    }
}
