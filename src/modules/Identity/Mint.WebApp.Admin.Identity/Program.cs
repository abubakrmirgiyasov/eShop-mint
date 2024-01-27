using Mint.Domain.Common;
using Mint.Domain.DTO_s.MessageBroker;
using Mint.Infrastructure.MessageBrokers;
using Mint.WebApp.Admin.Identity;
using Mint.WebApp.Admin.Identity.Services;
using Mint.WebApp.Extensions;
using Mint.WebApp.Extensions.Identities;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration.GetSection(nameof(AppSettings));
var appSettings = config.Get<AppSettings>();
builder.Services.Configure<AppSettings>(config);

builder.Services.AddMessageBusReceiver<UserImage>(appSettings?.MessageBroker);
builder.Services.AddHostedService<MessageBrokerBackgroundService>();

builder.Services.AddMediatR(options => options.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddDbContextServices(builder.Configuration, Constants.CONNECTION_STRING);

builder.Services.AddAuthenticationServices();
builder.Services.AdminIdentityServicesCollection();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddJwtConfiguration(appSettings!);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
