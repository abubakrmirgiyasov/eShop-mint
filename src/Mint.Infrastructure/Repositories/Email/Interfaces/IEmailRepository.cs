using Mint.Domain.Models.Email;

namespace Mint.Infrastructure.Repositories.Email;

public interface IEmailRepository
{
    Task SendTestEmailAsync(EmailOptions email);

    Task SendEmailConfirmation(EmailOptions email);

    Task SendEmailForgotPassword(EmailOptions email);

    Task SendEmailSpam(EmailOptions email);
}
