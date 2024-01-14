using Microsoft.EntityFrameworkCore;
using Mint.Domain.Exceptions;
using Mint.Domain.Models.Identity;
using Mint.Infrastructure;
using Mint.WebApp.Admin.Identity.Commands.Dtos;
using Mint.WebApp.Admin.Identity.Repositories.Interfaces;

namespace Mint.WebApp.Admin.Identity.Repositories;

internal sealed class AdminRepository(
    ApplicationDbContext context, 
    ILogger<AdminRepository> logger
) : IAdminRepository
{
    private readonly ApplicationDbContext _context = context;
    private readonly ILogger<AdminRepository> _logger = logger;

    public ApplicationDbContext Context => _context;

    /// <inheritdoc/>
    public async Task<User> FindByIdAsync(Guid id, CancellationToken cancellation = default)
    {
        try
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellation)
                ?? throw new UserNotFoundException($"Пользователь с Id={id} не найден");
        }
        catch (UserNotFoundException ex)
        {
            _logger.LogError("UserNotFoundException Message: {Message}", ex.Message);
            throw new UserNotFoundException(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task UpdateSettingsAsync(Guid userId, AdminSettingsDto settings, CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken)
                ?? throw new UserNotFoundException($"Пользователь с Id={userId} не найден");

            // TODO: Update fields

            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (UserNotFoundException ex)
        {
            _logger.LogError("UserNotFoundException Message: {Message}", ex.Message);
            throw new UserNotFoundException(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }
}
