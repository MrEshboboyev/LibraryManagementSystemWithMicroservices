using LibraryMS.Services.Membership.Application.Common.Models;
using LibraryMS.Services.Membership.Application.Mappings;
using LibraryMS.Services.Membership.Infrastructure.Configurations;
using LibraryMS.Services.Membership.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// configure database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "defaultPostgresConnection";
builder.Services.AddDatabaseConfiguration(connectionString);

// configure lifetime for services
builder.Services.AddApplicationServices();

// configure JWT
builder.Services.AddJwtAuthentication(builder.Configuration);

// configure swagger for JWT
builder.Services.AddSwaggerConfiguration();

// configure automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
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
