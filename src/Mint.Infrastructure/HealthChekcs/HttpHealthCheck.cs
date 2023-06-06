using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Mint.Infrastructure.HealthChekcs;

public class HttpHealthCheck : IHealthCheck
{
    private readonly static HttpClient _http = new();
    private readonly string _uri;

    public HttpHealthCheck(string uri)
    {
        _uri = uri;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await _http.GetAsync(_uri, cancellationToken);

            return response.IsSuccessStatusCode
                ? HealthCheckResult.Healthy($"Uri: '{_uri}', Status Code: '{response.StatusCode}'")
                : new HealthCheckResult(context.Registration.FailureStatus, $"Uri: '{_uri}', Status Code: '{response.StatusCode}'");
        }
        catch (Exception ex)
        {
            return new HealthCheckResult(context.Registration.FailureStatus, $"UriL '{_uri}', Exception: '{ex.Message}'", ex);
        }
    }
}
