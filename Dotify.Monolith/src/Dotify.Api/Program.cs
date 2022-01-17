using Dotify.Api.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarterInt();

var app = builder.Build();

app.UseCarter();
app.UseHttpsRedirection();

app.Run();
