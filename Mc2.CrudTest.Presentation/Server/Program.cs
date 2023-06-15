using Mc2.CrudTest.Presentation.Server.Extension;
using Microsoft.OpenApi.Models;

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

app.UseSwagger();
app.UseSwaggerUI();

//app.UseCors(corsBuilder =>
//{
//    CorsOptions cors = app.Configuration
//        .GetSection(CorsOptions.ConfigurationKey)
//        .Get<CorsOptions>();

//    corsBuilder.WithOrigins(cors!.AllowedOrigins);
//    corsBuilder.WithMethods(cors!.AllowedMethods);
//    corsBuilder.WithHeaders(cors!.AllowedHeaders);
//    corsBuilder.AllowCredentials();
//});

app.UseInfrastructure();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
