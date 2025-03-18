using AsyncAwaitTestWebApplication.Repositories;
using AsyncAwaitTestWebApplication.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<TestSetvice>();
builder.Services.AddScoped<TestRepository>();

var app = builder.Build();

app.Run();
