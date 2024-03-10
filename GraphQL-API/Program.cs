using GraphQL.Server;
using GraphQL.Types;
using GraphQL_API.GraphQL;
using GraphQL_API.GraphQL.GraphQueries;
using GraphQL_API.GraphQL.GraphTypes;
using GraphQL_API.Services;
using GraphQL_API.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Splat;
using System.Reflection;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

//GraphQL service registration 
builder.Services.AddSingleton<BooksQuery>();

builder.Services.AddGraphQL(options =>
{
    options.EnableMetrics = true; // For example, disable in production
}).AddSystemTextJson() // Use System.Text.Json for JSON serialization
    .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = builder.Environment.IsDevelopment())
    .AddGraphTypes(ServiceLifetime.Singleton);


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
