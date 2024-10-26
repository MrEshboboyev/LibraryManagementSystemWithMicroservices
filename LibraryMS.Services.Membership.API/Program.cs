using LibraryMS.Services.Membership.Application.Mappings;
using LibraryMS.Services.Membership.Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// configure database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "defaultPostgresConnection";
builder.Services.AddDatabaseConfiguration(connectionString);

// configure lifetime for services
builder.Services.AddApplicationServices();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
