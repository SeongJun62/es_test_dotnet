using EnsolTest.Controllers;
using EnsolTest.Services;
using Serilog;
using Serilog.Enrichers.CallerInfo;

var builder = WebApplication.CreateBuilder(args);

//Serilog
builder.Host.UseSerilog((context, services, configuration) =>
{
    configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .Enrich.WithCallerInfo(includeFileInfo : true, assemblyPrefix:"EnsolTest");
});

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.PropertyNamingPolicy = null;
});
builder.Services.AddHttpClient<SendService>(client =>
{
    client.Timeout = TimeSpan.FromSeconds(30);
});
builder.Services.AddHttpClient<TestController>(client =>
{
    client.Timeout = TimeSpan.FromSeconds(30);
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseMiddleware<EnsolTest.MiddleWares.LoggingMiddleware>();
app.UseAuthorization();


app.MapControllers();

app.Run();
