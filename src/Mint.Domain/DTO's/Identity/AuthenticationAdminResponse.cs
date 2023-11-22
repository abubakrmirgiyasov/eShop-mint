﻿using Mint.Domain.Common;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Mint.Domain.DTO_s.Identity;

public class AuthenticationAdminResponse
{
    [JsonPropertyName("_uid")]
    public Guid Id { get; set; }

    [JsonPropertyName("access_token")]
    public string Token { get; set; } = null!;

    [JsonPropertyName("_rr")]
    public int[] Roles { get; set; } = null!;
}
