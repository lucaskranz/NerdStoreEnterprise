using NSE.WebApp.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

#region Services
builder.Services.AddIdentityConfiguration();
builder.Services.AddMvcConfiguration();
builder.Services.RegisterServices();
#endregion

#region Configure
var app = builder.Build();

app.UseMvcConfiguration(app.Environment);
#endregion

app.Run();
