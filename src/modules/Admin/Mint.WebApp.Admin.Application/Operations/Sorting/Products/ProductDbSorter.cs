using Mint.Domain.Models.Admin.Products;
using Mint.WebApp.Admin.Application.Common;
using System.Linq.Expressions;

namespace Mint.WebApp.Admin.Application.Operations.Sorting.Products;

public class ProductDbSorter : DbSorter<Product>
{
    public static ProductDbSorter Instance => new();

    protected override Expression<Func<Product, object?>> GetDefaultProperty() => x => x.Id;

    protected override IEnumerable<KeyValuePair<string, Expression<Func<Product, object?>>>> GetProperties()
    {
        yield return WithProperty(x => x.ProductNumber);
        yield return WithProperty(x => x.ShortName);
        yield return WithProperty(x => x.Sku);
        yield return WithProperty(x => x.Price);
        yield return WithProperty(x => x.OldPrice);
        yield return WithProperty("Url", x => x.UrlToProduct);
    }
}
