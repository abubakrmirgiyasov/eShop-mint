using Mint.Application.Interfaces;
using Mint.Domain.Models.Admin.Tags;

namespace Mint.WebApp.Admin.Application.Operations.Repositories;

/// <summary>
///  Tag Repository
/// </summary>
public interface ITagRepository : IGenericReadRepository<Tag>
{
    /// <summary>
    /// Retrieves a list of tags based on the specified search phrase, pagination parameters, and cancellation token.
    /// </summary>
    /// <param name="searchPhrase"></param>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<(List<Tag>, int)> GetTagsAsync(
        string? searchPhrase = default, 
        int pageIndex = 0, 
        int pageSize = 25, 
        CancellationToken cancellationToken = default
    );
}
