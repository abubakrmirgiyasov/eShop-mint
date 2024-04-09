using Microsoft.Extensions.Options;
using Mint.Domain.Models.Email;
using System.Net;
using System.Net.Mail;
using Mint.Domain.Common;
using Mint.Application.Interfaces;

namespace Mint.WebApp.Email.Services;

public class EmailService(IOptions<AppSettings> emailConfig) : IEmailService
{
    const string _TemplatePath = "EmailTemplates\\{0}.html";

    private readonly AppSettings _appSettings = emailConfig.Value;

    public async Task SendEmail(EmailOptions email)
    {
        var mail = new MailMessage()
        {
            Subject = email.Subject,
            Body = email.Body,
            From = new MailAddress(_appSettings.MailConfig.From, _appSettings.MailConfig.Name),
            IsBodyHtml = _appSettings.MailConfig.IsBodyHtml
        };

        foreach (var toEmail in email.ToEmails)
            mail.To.Add(toEmail);

        var credential = new NetworkCredential(_appSettings.MailConfig.From, _appSettings.MailConfig.Password);

        var smtp = new SmtpClient()
        {
            Host = _appSettings.MailConfig.Host,
            Port = _appSettings.MailConfig.Port,
            EnableSsl = _appSettings.MailConfig.SSL,
            Credentials = credential,
            //UseDefaultCredentials = _emailConfig.UseDefaultCredentials,
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
