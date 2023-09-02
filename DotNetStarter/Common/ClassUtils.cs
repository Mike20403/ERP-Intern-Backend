using System.Linq.Expressions;

namespace DotNetStarter.Common
{
    public static class ClassUtils
    {
        public static string GetPropertyName<TClass>(Expression<Func<TClass, object>> predicate)
            where TClass : class
        {
            MemberExpression body = predicate.Body as MemberExpression;

            if (body == null)
            {
                UnaryExpression ubody = (UnaryExpression)predicate.Body;
                body = ubody.Operand as MemberExpression;
            }

            return body.Member.Name;
        }
    }
}
