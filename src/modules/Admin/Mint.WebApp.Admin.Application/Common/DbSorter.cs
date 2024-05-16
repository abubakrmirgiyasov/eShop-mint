using System.Collections.Frozen;
using System.Linq.Expressions;

namespace Mint.WebApp.Admin.Application.Common;

/// <summary>
/// A class representing the logic for sorting an entity by a specific property name.
/// </summary>
/// <typeparam name="T">The entity type for which the sorting occurs.</typeparam>
public abstract class DbSorter<T>
{
    /// <summary>
    /// Dictionary for searching expressions by property name.
    /// </summary>
    private readonly Lazy<FrozenDictionary<string, Expression<Func<T, object?>>>> _lookup;

    protected DbSorter()
    {
        _lookup = new Lazy<FrozenDictionary<string, Expression<Func<T, object?>>>>(CreateLookup);
    }

    /// <summary>
    /// Factory for creating a dictionary for searching an expression by property name.
    /// </summary>
    private FrozenDictionary<string, Expression<Func<T, object?>>> CreateLookup()
    {
        
        return GetProperties().ToFrozenDictionary(StringComparer.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Returns a list of properties available for sorting.
    /// </summary>
    /// <seealso cref="WithProperty(Expression{Func{T,object?}})"/>
    /// <seealso cref="WithProperty(string,Expression{Func{T,object?}})"/>
    protected abstract IEnumerable<KeyValuePair<string, Expression<Func<T, object?>>>> GetProperties();

    /// <summary>
    /// Returns the default sort expression.
    /// </summary>
    /// <returns></returns>
    protected abstract Expression<Func<T, object?>> GetDefaultProperty();

    public Expression<Func<T, object?>> GetSortingProperty(string? sortBy)
    {
        if (string.IsNullOrWhiteSpace(sortBy))
            return GetDefaultProperty();

        return _lookup.Value.GetValueOrDefault(sortBy, GetDefaultProperty());
    }

    /// <summary>
    /// Creates a relationship from a property name and an expression.
    /// </summary>
    /// <param name="propertyExpression">An expression with access to an entity property.</param>
    protected KeyValuePair<string, Expression<Func<T, object?>>> WithProperty(Expression<Func<T, object?>> propertyExpression)
    {
        ArgumentNullException.ThrowIfNull(propertyExpression);

        var propertyName = PropertyUtils.GetPropertyName(propertyExpression!);
        return WithProperty(propertyName, propertyExpression);
    }

    /// <summary>
    /// Creates a relationship from a property name and an expression.
    /// </summary>
    /// <param name="propertyName">Property Name</param>
    /// <param name="propertyExpression">An expression with access to an entity property.</param>
    public KeyValuePair<string, Expression<Func<T, object?>>> WithProperty(
        string propertyName,
        Expression<Func<T, object?>> propertyExpression)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(propertyName);
        ArgumentNullException.ThrowIfNull(propertyExpression);
    
        return new KeyValuePair<string, Expression<Func<T, object?>>>(propertyName, propertyExpression);
    }
}
