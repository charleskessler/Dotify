using Carter;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCarter();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapCarter();


app.Run();
