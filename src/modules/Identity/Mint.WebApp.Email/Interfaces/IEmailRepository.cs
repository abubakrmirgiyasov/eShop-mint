using Mint.WebApp.Email.Models;

namespace Mint.WebApp.Email.Interfaces;

public interface IEmailRepository
{
    Task SendTestEmail(EmailOptions email);

    Task SendEmailConfirmation(EmailOptions email);

    Task SendEmailForgotPassword(EmailOptions email);

    Task SendEmailSpam(EmailOptions email);
}
