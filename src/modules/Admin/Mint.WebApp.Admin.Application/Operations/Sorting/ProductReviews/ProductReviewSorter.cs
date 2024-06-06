using Mint.Domain.Models.Admin.Products;
using Mint.WebApp.Admin.Application.Common;
using System.Linq.Expressions;

namespace Mint.WebApp.Admin.Application.Operations.Sorting.ProductReviews;

public class ProductReviewSorter : DbSorter<ProductReview>
{
    public static ProductReviewSorter Instance => new();

    protected override Expression<Func<ProductReview, object?>> GetDefaultProperty() => x => x.Id;

    protected override IEnumerable<KeyValuePair<string, Expression<Func<ProductReview, object?>>>> GetProperties()
    {
        yield return WithProperty(x => x.CreatedDate);
        yield return WithProperty(x => x.Pluses);
        yield return WithProperty(x => x.Minuses);
        yield return WithProperty(x => x.Text);
        yield return WithProperty(x => x.CommentType);
        yield return WithProperty(x => x.Rating);
        yield return WithProperty(x => x.CountOfVoted);
    }
}
