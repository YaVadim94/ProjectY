using System;
using System.Linq.Expressions;
using AutoMapper;

namespace ProjectY.Application.Core.Extensions
{
    public static class MapperExtensions
    {
        public static IMappingExpression<TSource, TDest> MapMember<TSource, TDest, TMember>(
            this IMappingExpression<TSource, TDest> mappingExpression,
            Expression<Func<TDest, TMember>> destinationMember,
            Expression<Func<TSource, TMember>> sourceMember)
        {
            return mappingExpression
                .ForMember(destinationMember, opt => opt.MapFrom(sourceMember));
        }
    }
}
