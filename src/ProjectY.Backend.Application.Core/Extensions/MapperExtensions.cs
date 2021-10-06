using System;
using System.Linq.Expressions;
using AutoMapper;

namespace ProjectY.Backend.Application.Core.Extensions
{
    /// <summary>
    /// Расширения для маппера
    /// </summary>
    public static class MapperExtensions
    {
        /// <summary>
        /// Простой маппинг свойства
        /// </summary>
        public static IMappingExpression<TSource, TDest> MapMember<TSource, TDest, TMember>(
            this IMappingExpression<TSource, TDest> mappingExpression,
            Expression<Func<TDest, TMember>> destinationMember,
            Expression<Func<TSource, TMember>> sourceMember)
        {
            return mappingExpression
                .ForMember(destinationMember, opt => opt.MapFrom(sourceMember));
        }

        /// <summary>
        /// Проигнорировать маппинг свойства
        /// </summary>
        public static IMappingExpression<TSource, TDest>  IgnoreMember<TSource, TDest, TMember>(
            this IMappingExpression<TSource, TDest> mappingExpression,
            Expression<Func<TDest, TMember>> destinationMember)
        {
            return mappingExpression
                .ForMember(destinationMember, opt => opt.Ignore());
        }
    }
}
