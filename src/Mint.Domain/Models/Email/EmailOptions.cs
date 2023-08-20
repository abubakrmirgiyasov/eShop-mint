#nullable disable

namespace Mint.Domain.Models.Email;

public class EmailOptions
{
    public List<KeyValuePair<string, string>> Placeholders { get; set; }

    public List<string> ToEmails { get; set; }

    public string Subject { get; set; }

    public string Body { get; set; }
}
