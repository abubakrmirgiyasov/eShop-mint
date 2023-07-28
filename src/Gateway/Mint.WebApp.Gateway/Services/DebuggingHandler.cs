﻿namespace Mint.WebApp.Services;

public class DebuggingHandler : DelegatingHandler
{
    public DebuggingHandler() { }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = await base.SendAsync(request, cancellationToken);
        response.Headers.Add("auth", "test");
        return response;
    }
}
