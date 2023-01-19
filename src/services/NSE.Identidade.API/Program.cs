using NSE.Identidade.API.Configuration;

#region Configuration

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<StartupBase>();
}

#endregion

#region Services

builder.Services.AddIdentityConfiguration(builder.Configuration);

builder.Services.AddApiConfiguration();

builder.Services.AddSwaggerConfiguration();

#endregion

#region Configure

var app = builder.Build();

app.UseSwaggerConfiguration();

app.UseApiConfiguration(app.Environment);

#endregion

app.Run();
