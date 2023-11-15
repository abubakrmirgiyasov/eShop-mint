using Mint.Domain.Common;
using System.ComponentModel;

namespace Mint.Domain.DTO_s.Identity;

public class AuthenticationAdminResponse
{
    [DisplayName("_iid")]
    public Guid Id { get; set; }

    [DisplayName("access_token")]
    public string Token { get; set; } = null!;

    [DisplayName("rr")]
    public Roles[] Roles { get; set; } = null!;
}
