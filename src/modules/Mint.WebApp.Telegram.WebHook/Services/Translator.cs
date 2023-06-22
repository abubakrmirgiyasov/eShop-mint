using Mint.WebApp.Telegram.WebHook.Interfaces;
using Mint.WebApp.Telegram.WebHook.Models;
using System.Text;
using System.Text.Json;

namespace Mint.WebApp.Telegram.WebHook.Services;

/// <summary>
/// Translator class
/// </summary>
public class Translator : ITranslator
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _serializerOptions;

    /// <summary>
    /// Ctor
    /// </summary>
    /// <param name="client"></param>
    /// <param name="serializerOptions"></param>
    public Translator(HttpClient client, JsonSerializerOptions serializerOptions)
    {
        _client = client;
        _serializerOptions = serializerOptions;
    }

    /// <summary>
    /// TranslateAsync
    /// </summary>
    /// <param name="fromLanguage"></param>
    /// <param name="toLanguage"></param>
    /// <param name="text"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException">If Azure Translator API did not return success status code. See details in message.</exception>
    public async Task<string> TranslateAsync(string fromLanguage, string toLanguage, string text)
    {
        var route = $"/translate?api-version=3.0&from={fromLanguage}&to={toLanguage}";
        var body = new object[] { new { Text = text } };
        var requestBody = JsonSerializer.Serialize(body);
        var response = await _client.PostAsync(
            route,
            new StringContent(requestBody, Encoding.UTF8, "application/json"));
    
        if (!response.IsSuccessStatusCode)
            throw new InvalidOperationException(
                $"Azure Translator API did not return a success status code. ({await response.Content.ReadAsStringAsync()})");
    
        var responseData = await response.Content.ReadAsStringAsync();
        var translations = JsonSerializer.Deserialize<List<TranslationResponse>>(responseData, _serializerOptions)!;
        return translations.First().Translations.First().Text;
    }
}
