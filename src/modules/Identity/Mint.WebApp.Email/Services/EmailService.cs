using Microsoft.Extensions.Options;
using Mint.WebApp.Email.Common;
using Mint.Domain.Models.Email;
using System.Net;
using System.Net.Mail;
using Mint.Infrastructure.Services.Interfaces;

namespace Mint.WebApp.Email.Services;

public class EmailService : IEmailService
{
    const string _TemplatePath = "EmailTemplates\\{0}.html";

    private readonly MailConfig _emailConfig;

    public EmailService(IOptions<MailConfig> emailConfig)
    {
        _emailConfig = emailConfig.Value;
    }

    public async Task SendEmail(EmailOptions email)
    {
        var mail = new MailMessage()
        {
            Subject = email.Subject,
            Body = email.Body,
            From = new MailAddress(_emailConfig.From, _emailConfig.Name),
            IsBodyHtml = _emailConfig.IsBodyHtml
        };

        foreach (var toEmail in email.ToEmails)
            mail.To.Add(toEmail);

        var credential = new NetworkCredential(_emailConfig.Login, _emailConfig.Password);

        var smtp = new SmtpClient()
        {
            Host = _emailConfig.Host,
            Port = _emailConfig.Port,
            EnableSsl = _emailConfig.SSL,
            //UseDefaultCredentials = _emailConfig.UseDefaultCredentials,
            Credentials = credential,
        };

        await smtp.SendMailAsync(mail);
    }

    public string GetEmailBody(string templateName)
    {
            return File.ReadAllText(string.Format(_TemplatePath, templateName));
        //if (File.Exists(_TemplatePath))
        //else
        //    return File.ReadAllText(GenerateEmailTemplate(_TemplatePath, templateName));
    }

    public string GenerateEmailTemplate(string templatePath, string templateName)
    {
        return "";
    }

    public string UpdatePlaceholders(string text, List<KeyValuePair<string, string>> placeholders)
    {
        if (!string.IsNullOrEmpty(text) && placeholders != null)
        {
            foreach (var placeholder in placeholders)
            {
                if (text.Contains(placeholder.Key))
                {
                    text = text.Replace(placeholder.Key, placeholder.Value);
                }
            }
        }
        return text;
    }
}
