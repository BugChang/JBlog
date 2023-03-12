using System.Linq.Expressions;

namespace JBlog.Common.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {

            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            var expr1WithParentheses = Expression.MakeBinary(ExpressionType.AndAlso, expr1.Body, Expression.Constant(true));

            return Expression.Lambda<Func<T, bool>>
                (Expression.OrElse(expr1WithParentheses, invokedExpr), expr1.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }

    }

}
