using LibraryMS.Services.Auth.Application.Common.Interfaces;
using LibraryMS.Services.Auth.Application.Common.Utility;
using LibraryMS.Services.Auth.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LibraryMS.Services.Auth.Infrastructure.Data;

public class DbInitializer(UserManager<AppUser> userManager,
    RoleManager<IdentityRole> roleManager,
    AuthDbContext db) : IDbInitializer
{
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;
    private readonly AuthDbContext _db = db;

    public async Task InitializeAsync()
    {
        try
        {
            // Migrate database changes
            if (_db.Database.GetPendingMigrations().Any())
            {
                await _db.Database.MigrateAsync();
            }

            // Check if the "Admin" role exists, if not, create roles and the admin user
            if (!await _roleManager.RoleExistsAsync(SD.Role_Architect))
            {
                // Create roles
                await _roleManager.CreateAsync(new IdentityRole(SD.Role_Architect));
                await _roleManager.CreateAsync(new IdentityRole(SD.Role_User));

                // Create admin user
                var adminForDb = new AppUser
                {
                    FullName = "Admin FullName",
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    EmailConfirmed = true,
                    NormalizedUserName = "ADMIN@EXAMPLE.COM",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM"
                };

                await _userManager.CreateAsync(adminForDb, "Admin*123");

                // Assign role to admin
                var admin = await _userManager.FindByEmailAsync("admin@example.com")
                    ?? throw new Exception("Admin not found!");
                await _userManager.AddToRoleAsync(admin, SD.Role_Architect);

                //// Create user profile for admin
                //var userProfile = new UserProfile
                //{
                //    Bio = "Admin",
                //    CompanyName = "JobBoardApp",
                //    UserId = adminForDb.Id,
                //    Website = "jobboardapp.com"
                //};

                //await _db.UserProfiles.AddAsync(userProfile);
                await _db.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            // Handle or log the exception
            throw new Exception("Error initializing the database", ex);
        }
    }
}