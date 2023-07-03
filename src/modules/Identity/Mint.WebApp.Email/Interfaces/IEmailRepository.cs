using Mint.Domain.Models;

namespace Mint.WebApp.Email.Interfaces;

public interface IEmailRepository
{
    Task SendTestEmail(User user);

    Task SendEmailConfirmation(User user);

    Task SendEmailForgotPassword(User user);
}
