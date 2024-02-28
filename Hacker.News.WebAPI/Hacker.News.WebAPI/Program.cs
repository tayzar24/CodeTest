using Hacker.News.WebAPI.Extension;
using log4net.Config;
using log4net;
using Hacker.News.AppService.Extension;
using Hacker.News.Common.Log;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
XmlConfigurator.Configure(logRepository, new FileInfo("Config/log4net.config"));
builder.Services.AddSingleton(LogManager.GetLogger(typeof(Program)));
builder.Logging.AddLog4Net();

// Add services to the container.

builder.Services.AddCors(builder.Configuration);
builder.Services.AddScoped<LogService>();
builder.Services.AddService();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
