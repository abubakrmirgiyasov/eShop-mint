#nullable disable

namespace Mint.WebApp.Email.Common;

public class MailConfig
{
    public string From { get; set; }

    public string Host { get; set; }

    public int Port { get; set; }

    public string Name { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public bool SSL { get; set; }

    public bool IsBodyHtml { get; set; }
    
    public bool UseDefaultCredentials { get; set; }
}
