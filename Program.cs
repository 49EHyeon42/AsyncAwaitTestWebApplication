using AsyncAwaitTestWebApplication.Repositories;
using AsyncAwaitTestWebApplication.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<TestService>();
builder.Services.AddScoped<TestRepository>();

var app = builder.Build();

app.MapControllers();

app.Run();
