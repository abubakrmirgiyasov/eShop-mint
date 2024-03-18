using Mint.Domain.Models.Admin;

namespace Mint.Infrastructure.Repositories.Admin;

/// <summary>
///  Tag Repository CRUD functions
/// </summary>
public interface ITagRepository : IBaseRepository<Tag, Guid>
{
    /// <summary>
    /// This method returns all tags async
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<Tag>> GetTagsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// This method deletes single by id tag
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteTagAsync(Guid id, CancellationToken cancellationToken = default);
}
