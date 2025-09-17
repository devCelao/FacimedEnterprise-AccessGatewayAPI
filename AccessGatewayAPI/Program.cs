using AccessGatewayAPI.Configuration;
using Microsoft.OpenApi.Models;
using WebApiCore.Configuration;

var builder = WebApplication.CreateBuilder(args);
bool isDevelopment = builder.Environment.IsDevelopment();
builder.AddJsonFile();

if (isDevelopment)
{
    builder.Configuration.AddUserSecrets<Program>();
}




// Add os controllers
builder.Services.AddExtensionConfiguration();

// Add configurações do cors
builder.Services.AddCustomCors();

// Add configurações do swagger
var infoApi = new OpenApiInfo
{
    Version = "v1",
    Title = "Gayteway Access API",
    Description = "API que integra Authentication e UserManagement",
    Contact = new()
    {
        Name = "",
        Email = "",
        Url = new Uri(uriString: "https://www.linkedin.com/in/fernandes-marcelo/")
    },
    License = new()
    {
        Name = "MIT",
        Url = new Uri(uriString: "https://opensorce.org/licenses/MIT")
    }
};

builder.Services.AddSwaggerConfiguration(infoApi);

// Add os services usados na aplicacao
builder.Services.AddRegisterServices(builder.Configuration);


var app = builder.Build();


app.UseSwaggerConfiguration(isDevelopment);

app.UseCustomCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();