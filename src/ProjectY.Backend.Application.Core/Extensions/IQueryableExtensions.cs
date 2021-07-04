using System.Linq;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Query.Validator;

namespace ProjectY.Backend.Application.Core.Extensions
{
    /// <summary>
    /// Расширения для <see cref="IQueryable"/>
    /// </summary>
    public static class IQueryableExtensions
    {
        /// <summary>
        /// Применить Odata выражение к запросу
        /// </summary>
        public static IQueryable<T> ApplyOptions<T>(this IQueryable<T> query, ODataQueryOptions options)
        {
            options.Validate(new ODataValidationSettings());

            var settings = new ODataQuerySettings
            {
                EnableConstantParameterization = true,
                HandleNullPropagation = HandleNullPropagationOption.False,
                EnsureStableOrdering = false,
            };

            return options.ApplyTo(query, settings) as IQueryable<T>;
        }
    }
}
