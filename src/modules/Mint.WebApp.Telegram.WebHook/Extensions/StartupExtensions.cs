using Mint.WebApp.Telegram.WebHook.Common;
using Mint.WebApp.Telegram.WebHook.Interfaces;
using Mint.WebApp.Telegram.WebHook.Services;
using System.Text.Json;
using Telegram.Bot;

namespace Mint.WebApp.Telegram.WebHook.Extensions;

public static class StartupExtensions
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<BotConfiguration>(builder.Configuration.GetRequiredSection(BotConfiguration.SectionPath));

        var botConfiguration =
            builder.Configuration.GetRequiredConfigurationInstance<BotConfiguration>(BotConfiguration.SectionPath);
        botConfiguration.Validate();

        builder.Services
            .AddHttpClient(nameof(WebHook))
            .AddTypedClient<ITelegramBotClient>();

        builder.Services.AddSingleton(_ => new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            WriteIndented = false,
        });

        builder.Services.AddScoped<ITranslator, Translator>();
        builder.Services.AddScoped<ILanguageManager, StubLanguageManager>();

        builder.Services.AddScoped<ITelegramBotClient>(service =>
        {
            var factory = service.GetRequiredService<IHttpClientFactory>();
            var options = new TelegramBotClientOptions(botConfiguration.BotToken);
            return new TelegramBotClient(options, factory.CreateClient(nameof(WebHook)));
        });
        builder.Services.AddScoped<UpdateHandlerServiceBase, TranslatorUpdateHandlerService>();

        builder.Services.AddCommandManager((service, builder) =>
        {
            const int ReplyKeyboardColumns = 3;

            var languageManager = service.GetRequiredService<ILanguageManager>();
            var serializeOptions = service.GetRequiredService<JsonSerializerOptions>();
            var translator = service.GetRequiredService<ITranslator>();

            builder.RegisterCommand(new StartCommand());
            builder.RegisterCommand(new SourceLanguageSetterCommand(languageManager, serializeOptions, ReplyKeyboardColumns));
            //
        });
        
        builder.Services
            .AddControllers()
            .AddNewtonsoftJson();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddHostedService<WebHookService>();
        return builder;
    }

    public static void Configure(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }
}
