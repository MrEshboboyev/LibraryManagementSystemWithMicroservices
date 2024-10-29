using LibraryMS.Services.Auth.Application.Common.Interfaces.External;
using LibraryMS.Services.Auth.Application.Common.Models;
using LibraryMS.Services.Auth.Application.Mappings;
using LibraryMS.Services.Auth.Infrastructure.Configurations;
using LibraryMS.Services.Auth.Infrastructure.ExternalClients;
using LibraryMS.Services.Auth.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// configure database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "defaultPostgresConnection";
builder.Services.AddDatabaseConfiguration(connectionString);

// add JwtOptions configuring
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtSettings"));

// configure identity
builder.Services.AddIdentityConfiguration();

// configure lifetime for services
builder.Services.AddApplicationServices();

// Register external services
builder.Services.AddExternalServices(builder.Configuration);

// configure JWT
builder.Services.AddJwtAuthentication(builder.Configuration);

// configure swagger for JWT
builder.Services.AddSwaggerConfiguration();

// configure automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
await app.SeedDatabaseAsync();
app.Run();
