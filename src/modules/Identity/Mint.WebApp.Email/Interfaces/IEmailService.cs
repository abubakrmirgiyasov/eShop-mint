using Mint.Domain.Models;

namespace Mint.WebApp.Email.Interfaces;

public interface IEmailService
{
    Task SendEmail(User user);

    string GetEmailBody(string text);

    string UpdatePlaceholders(string text, List<KeyValuePair<string, string>> keyValuePairs);
}
