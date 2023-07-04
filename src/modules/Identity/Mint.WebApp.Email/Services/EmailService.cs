using Mint.Domain.Models;
using Mint.WebApp.Email.Interfaces;

namespace Mint.WebApp.Email.Services;

public class EmailService : IEmailService
{
    public Task SendEmail(User user)
    {
        throw new NotImplementedException();
    }

    public string GetEmailBody(string text)
    {
        throw new NotImplementedException();
    }

    public string UpdatePlaceholders(string text, List<KeyValuePair<string, string>> keyValuePairs)
    {
        throw new NotImplementedException();
    }
}
