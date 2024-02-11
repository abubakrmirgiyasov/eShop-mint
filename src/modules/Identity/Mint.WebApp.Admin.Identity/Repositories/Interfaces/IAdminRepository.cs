using Mint.Domain.Models.Identity;
using Mint.Infrastructure.Repositories;
using Mint.WebApp.Admin.Identity.Operations.Dtos;

namespace Mint.WebApp.Admin.Identity.Repositories.Interfaces;

/// <summary>
/// 
/// </summary>
internal interface IAdminRepository : IBaseRepository<User, Guid>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="settings"></param>
    /// <exception cref="UserNotFoundException"></exception>
    /// <exception cref="Exception"></exception>
    /// <returns></returns>
    Task UpdateSettingsAsync(Guid userId, AdminSettingsDto settings, CancellationToken cancellationToken = default);
}
