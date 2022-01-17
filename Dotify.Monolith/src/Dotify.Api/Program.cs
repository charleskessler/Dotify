
using Dotify.Api.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFeatures();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.DocInclusionPredicate((s, description) =>
{
    foreach (var metaData in description.ActionDescriptor.EndpointMetadata)
    {
        if (metaData is IIncludeOpenApi)
        {
            return true;
        }
    }
    return false;
}));


builder.Services.AddCarter();
builder.Services.AddMongo();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapCarter();


app.Run();
