using Mc2.CrudTest.Presentation.Server.Extension;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Customer API", Version = "v1" });
});

builder.AddInfrastructure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger.json", " Web API");
        options.EnableFilter();
        options.DisplayRequestDuration();
        options.ShowExtensions();
        options.ShowCommonExtensions();
        options.EnableValidator();
        options.EnableDeepLinking();
        options.DocExpansion(DocExpansion.List);
    });
}

app.UseInfrastructure();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
