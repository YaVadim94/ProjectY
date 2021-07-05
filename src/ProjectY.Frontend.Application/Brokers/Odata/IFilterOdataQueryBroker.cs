using System;
using System.Linq.Expressions;

namespace ProjectY.Frontend.Application.Brokers.Odata
{
    /// <summary>
    /// Брокер для построения Odata запросов
    /// </summary>
    public interface IFilterOdataQueryBroker<TContract>
    {
        /// <summary>
        /// Получить Odata запрос-равенство 
        /// </summary>
        string GetEqualityQuery<TProperty>(Expression<Func<TContract, TProperty>> expression, object value);

        /// <summary>
        /// Получить Odata запрос-больше 
        /// </summary>
        string GetGreaterThanQuery<TProperty>(Expression<Func<TContract, TProperty>> expression, object value);

        /// <summary>
        /// Получить Odata запрос-меньше 
        /// </summary>
        string GetLessThanQuery<TProperty>(Expression<Func<TContract, TProperty>> expression, object value);
    }
}
