using Mint.Domain.Models.Email;
using Mint.Infrastructure.Services.Interfaces;

namespace Mint.Infrastructure.Repositories.Email;

public class EmailRepository : IEmailRepository
{
    const string _TestEmail = "Hello {{Login}}, This is test email subject from book store web app";

    private readonly IEmailService _emailService;

    public EmailRepository(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public async Task SendTestEmailAsync(EmailOptions email)
    {
        email.Subject = _emailService.UpdatePlaceholders(_TestEmail, email.Placeholders);
        email.Body = _emailService.UpdatePlaceholders(_emailService.GetEmailBody("TestEmail"), email.Placeholders);
        await _emailService.SendEmail(email);
    }

    public Task SendEmailConfirmation(EmailOptions email)
    {
        throw new NotImplementedException();
    }

    public Task SendEmailForgotPassword(EmailOptions email)
    {
        throw new NotImplementedException();
    }

    public Task SendEmailSpam(EmailOptions email)
    {
        throw new NotImplementedException();
    }
}
