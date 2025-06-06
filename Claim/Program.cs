using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Claim.Controller;
using Claim.Domain;
using System.Reflection;
using MediatR;
using Claim.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Configure MongoDB settings
builder.Services.Configure<MongoSettings>(
    builder.Configuration.GetSection("MongoSettings"));

// Register MongoClient
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoSettings>>().Value;
    return new MongoClient(settings.ConnectionString);
});

// Register IMongoDatabase
builder.Services.AddSingleton<IMongoDatabase>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoSettings>>().Value;
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(settings.DatabaseName);
});

// Register Claim collection
builder.Services.AddScoped<IMongoCollection<ClaimDomain>>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoSettings>>().Value;
    var database = sp.GetRequiredService<IMongoDatabase>();
    return database.GetCollection<ClaimDomain>(settings.ClaimsCollectionName);
});

//  MediatR setup for version 11
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddScoped<IClaimRepository, ClaimImplementation>();


// Add controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
