using System;
using System.Linq.Expressions;
using ProjectY.Frontend.Application.Exceptions;

namespace ProjectY.Frontend.Application.Brokers.Odata
{
    /// <summary>
    /// Брокер для построения строк фильтрации Odata
    /// </summary>
    public class FilterODataQueryBroker<TContract> : IFilterOdataQueryBroker<TContract>
    {
        /// <summary>
        /// Получить Odata запрос-равенство 
        /// </summary>
        public string GetEqualityQuery<TProperty>(Expression<Func<TContract, TProperty>> expression, object value)
        {
            var memberExpression = ValidateMemberExpression(expression);

            var propType = memberExpression.Type.Name.ToLowerInvariant();
            var propName = memberExpression.Member.Name;

            var stringValue = propType switch
            {
                "string" => $"'{value}'",
                _ => value.ToString()
            };

            return $"$filter={propName} eq {stringValue}";
        }

        /// <summary>
        /// Получить Odata запрос-больше 
        /// </summary>
        public string GetGreaterThanQuery<TProperty>(Expression<Func<TContract, TProperty>> expression, object value)
        {
            var memberExpression = ValidateMemberExpression(expression);

            var propType = memberExpression.Type.Name.ToLowerInvariant();
            var propName = memberExpression.Member.Name;

            var stringValue = propType switch
            {
                "datetime" => value.ToString(),
                "int" => value.ToString(),
                "long" => value.ToString(),
                _ => throw new ArgumentOutOfRangeException(propName)
            };

            return $"$filter={propName} gt {stringValue}";
        }

        /// <summary>
        /// Получить Odata запрос-меньше 
        /// </summary>
        public string GetLessThanQuery<TProperty>(Expression<Func<TContract, TProperty>> expression, object value)
        {
            var memberExpression = ValidateMemberExpression(expression);

            var propType = memberExpression.Type.Name.ToLowerInvariant();
            var propName = memberExpression.Member.Name;

            var stringValue = propType switch
            {
                "datetime" => value.ToString(),
                "int" => value.ToString(),
                "long" => value.ToString(),
                _ => throw new ArgumentOutOfRangeException(propName)
            };

            return $"$filter={propName} lt {value}";
        }

        private MemberExpression ValidateMemberExpression<TProperty>(Expression<Func<TContract, TProperty>> expression)
        {
            if (!(expression is LambdaExpression lambdaExpression))
                throw new OdataQueryException();

            if (!(lambdaExpression.Body is MemberExpression memberExpression))
                throw new OdataQueryException();

            return memberExpression;
        }
    }
}
