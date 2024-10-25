using LibraryMS.Services.Auth.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryMS.Services.Auth.Infrastructure.Data;

internal sealed class AuthDbContext(DbContextOptions<AuthDbContext> options) 
    : IdentityDbContext<AppUser>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // USER ENTITY
        modelBuilder.Entity<AppUser>()
            .HasKey(u => u.Id);
    }
}