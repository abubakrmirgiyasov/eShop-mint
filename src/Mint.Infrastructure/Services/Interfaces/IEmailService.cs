using Mint.Domain.Models.Email;

namespace Mint.Infrastructure.Services.Interfaces;

public interface IEmailService
{
    Task SendEmail(EmailOptions email);

    string GetEmailBody(string templateName);

    string UpdatePlaceholders(string text, List<KeyValuePair<string, string>> placeholders);

    string GenerateEmailTemplate(string templatePath, string templateName);
}
