#nullable disable

namespace Mint.WebApp.Email.Models;

public class EmailOptions
{
    public List<KeyValuePair<string, string>> Placeholders { get; set; }

    public List<string> ToEmails { get; set; }

    public string Subject { get; set; }

    public string Body { get; set; }
}
