using Association.Application;
using Association.Persistence;
using Association.WebAPI;
using Association.WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddCors(opt =>
    opt.AddDefaultPolicy(p =>
    {
        p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    })
);

var app = builder.Build();

if (app.Environment.IsProduction())
    app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

// TODO: Db migration işlemi yazılacak.

app.UseAuthorization();

app.MapControllers();

#region Cors Configuration
const string webApiConfigurationSection = "WebAPIConfiguration";

WebApiConfiguration webApiConfiguration =
    app.Configuration.GetSection(webApiConfigurationSection).Get<WebApiConfiguration>()
    ?? throw new InvalidOperationException($"\"{webApiConfigurationSection}\" section cannot found in configuration.");

app.UseCors(opt => opt.WithOrigins(webApiConfiguration.AllowedOrigins).AllowAnyHeader().AllowAnyMethod().AllowCredentials());
#endregion

app.Run();
