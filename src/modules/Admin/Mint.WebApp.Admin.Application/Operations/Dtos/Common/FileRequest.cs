using Microsoft.AspNetCore.Http;

namespace Mint.WebApp.Admin.Application.Operations.Dtos.Common;

public sealed record FileRequest(IFormFileCollection Files);
