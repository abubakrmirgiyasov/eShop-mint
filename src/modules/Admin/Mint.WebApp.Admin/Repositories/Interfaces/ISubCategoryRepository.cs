using Mint.Domain.Models.Admin.Categories;
using Mint.Infrastructure.Repositories;

namespace Mint.WebApp.Admin.Repositories.Interfaces;

/// <summary>
/// Sub Category Base Repository
/// </summary>
public interface ISubCategoryRepository : IBaseRepository<SubCategory, Guid>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
