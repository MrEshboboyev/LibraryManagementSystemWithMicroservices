using LibraryMS.Services.Auth.Application.Mappings;
using LibraryMS.Services.Auth.Infrastructure.Configurations;
using LibraryMS.Services.Auth.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// configure database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "defaultPostgresConnection";
builder.Services.AddDatabaseConfiguration(connectionString);

// configure identity
builder.Services.AddIdentityConfiguration();

// configure lifetime for services
builder.Services.AddApplicationServices();

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

app.UseAuthorization();

app.MapControllers();
await app.SeedDatabaseAsync();
app.Run();
