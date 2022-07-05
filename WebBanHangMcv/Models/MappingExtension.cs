using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebBanHangMcv.Models
{
    public static class FunctionCompositionExtensions
    {
        public static Expression<Func<TReplacement, TSelector>> Compose<TSource, TReplacement, TSelector>(this Expression<Func<TSource, TSelector>> outer, Expression<Func<TReplacement, TSource>> inner)
        {
            return Expression.Lambda<Func<TReplacement, TSelector>>(
                ParameterReplacer.Replace(outer.Body, outer.Parameters[0], inner.Body),
                inner.Parameters[0]);
        }
    }

    public class ParameterReplacer : ExpressionVisitor
    {
        private ParameterExpression _parameter;
        private Expression _replacement;

        private ParameterReplacer(ParameterExpression parameter, Expression replacement)
        {
            _parameter = parameter;
            _replacement = replacement;
        }

        public static Expression Replace(Expression expression, ParameterExpression parameter, Expression replacement)
        {
            return new ParameterReplacer(parameter, replacement).Visit(expression);
        }

        protected override Expression VisitParameter(ParameterExpression parameter)
        {
            if (parameter == _parameter)
            {
                return _replacement;
            }
            return base.VisitParameter(parameter);
        }
    }

    public class MappingHelper
    {
        public static IEnumerable<Expression<Func<TReplacement, TSelector>>> GetMappedSelectors<TSource, TReplacement, TSelector>(params Expression<Func<TSource, TSelector>>[] selectors)
        {
            if (selectors == null)
                yield return null;

            Expression<Func<TReplacement, TSource>> mapper = Mapper.Engine.CreateMapExpression<TReplacement, TSource>();
            foreach (var selector in selectors)
            {
                yield return selector.Compose(mapper);
            }
        }

        public static Expression<Func<TReplacement, TSelector>> GetMappedSelector<TSource, TReplacement, TSelector>(Expression<Func<TSource, TSelector>> selector)
        {
            if (selector == null)
                return null;

            Expression<Func<TReplacement, TSource>> mapper = Mapper.Engine.CreateMapExpression<TReplacement, TSource>();
            return selector.Compose(mapper);
        }

        public static IEnumerable<Func<TReplacement, TSelector>> GetMappedSelector<TSource, TReplacement, TSelector>(params Func<TSource, TSelector>[] selectors)
        {
            Func<TReplacement, TSource> mapper = Mapper.Engine.CreateMapExpression<TReplacement, TSource>().Compile();
            foreach (var selector in selectors)
            {
                yield return x => selector(mapper(x));
            }
        }
    }
}