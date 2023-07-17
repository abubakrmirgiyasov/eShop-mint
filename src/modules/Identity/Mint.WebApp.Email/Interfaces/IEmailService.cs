using Mint.WebApp.Email.Models;

namespace Mint.WebApp.Email.Interfaces;

public interface IEmailService
{
    Task SendEmail(EmailOptions email);

    string GetEmailBody(string templateName);

    string UpdatePlaceholders(string text, List<KeyValuePair<string, string>> placeholders);

    string GenerateEmailTemplate(string templatePath, string templateName);
}
