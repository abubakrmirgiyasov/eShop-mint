using Mint.WebApp.Admin.DTO_s;

namespace Mint.WebApp.Admin.Repositories.Interfaces;

/// <summary>
///  interface of Tag Repository
/// </summary>
public interface ITagRepository
{
    /// <summary>
    /// This methods gets all tags
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<TagFullViewModel>> GetTagsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// This method returns single tag by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TagFullViewModel> GetTagByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// This method adds new tag to db
    /// </summary>
    /// <param name="model"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task NewTagAsync(TagFullBindingModel model, CancellationToken cancellationToken = default);

    /// <summary>
    /// This method updates single tag
    /// </summary>
    /// <param name="model"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdateTagAsync(TagFullBindingModel model, CancellationToken cancellationToken = default);

    /// <summary>
    /// This method deletes single by id tag
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteTagAsync(Guid id, CancellationToken cancellationToken = default);
}
