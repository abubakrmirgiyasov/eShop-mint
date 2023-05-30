using System.Net.Http.Headers;

namespace Mint.MAUI.App.Services;

internal class Request<T>
{
    private HttpClient _client;
    private readonly bool _auth;

    internal HttpClient Client { get => _client; set => _client = value; }

    internal Request(bool auth)
    {
        _auth = auth;
        SetHttpClient();
    }

    private void SetHttpClient()
    {
        Client = new HttpClient() { BaseAddress = new Uri("https://192.168.0.104:7121/") };
        Client.DefaultRequestHeaders.Accept.Clear();
        Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        if (_auth)
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "");
    }

    internal async Task<T> GetRequestAsync(string route)
    {
        try
        {
            var response = await _client.GetAsync(route);
            var query = await response.Content.ReadAsStringAsync();
            return new JsonResponse<T>().GetResponse(response, query);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
