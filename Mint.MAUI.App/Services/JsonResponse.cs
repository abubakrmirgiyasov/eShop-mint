using Newtonsoft.Json;

namespace Mint.MAUI.App.Services;

internal class JsonResponse<T>
{
    internal T GetResponse(HttpResponseMessage response, string query)
    {
        if (response.IsSuccessStatusCode)
            return JsonConvert.DeserializeObject<T>(query);

        throw new Exception(JsonConvert.DeserializeObject<string>(query));
    }
}
