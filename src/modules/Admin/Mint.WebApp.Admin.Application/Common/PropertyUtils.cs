using System.Linq.Expressions;
using System.Reflection;

namespace Mint.WebApp.Admin.Application.Common;

public static class PropertyUtils
{
    /// <summary>
    /// Returns the property expression from the lambda expression <paramref name="selector"/>.
    /// </summary>
    /// <typeparam name="T">The type of the source object.</typeparam>
    /// <param name="selector">Lambda expressions for property selection.</param>
    /// <exception cref="ArgumentException"></exception>
    public static Expression GetPropertyExpression<T>(Expression<Func<T, object>> selector)
    {
        return selector.Body switch
        {
            UnaryExpression { Operand: MemberExpression memberExpression } => memberExpression,
            UnaryExpression => throw new ArgumentException("Expected property select in lambda body.", nameof(selector)),
            MemberExpression memberExpression => memberExpression,
            _ => throw new ArgumentException("Expected property select in lambda body.", nameof(selector))
        };
    }

    /// <summary>
    /// Returns an instance of <see cref="PropertyInfo"/> for the property specified in <paramref name="selector"/>.
    /// </summary>
    /// <typeparam name="T">The type of the source object.</typeparam>
    /// <param name="selector">Lambda expressions for property selection.</param>
    /// <returns></returns>
    public static PropertyInfo GetPropertyInfo<T>(Expression<Func<T, object>> selector)
    {
        var memberExpression = (MemberExpression)GetPropertyExpression(selector);
        return (PropertyInfo)memberExpression.Member;
    }

    /// <summary>
    /// Returns the name of the property specified in <paramref name="selector"/>.
    /// </summary>
    /// <typeparam name="T">The type of the source object.</typeparam>
    /// <param name="selector">Lambda expressions for property selection.</param>
    public static string GetPropertyName<T>(Expression<Func<T, object>> selector)
    {
        return GetPropertyInfo(selector).Name;
    }
}
