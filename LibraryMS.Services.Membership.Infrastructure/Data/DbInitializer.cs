using LibraryMS.Services.Membership.Application.Common.Interfaces;
using LibraryMS.Services.Membership.Application.Common.Utility;
using Microsoft.EntityFrameworkCore;

namespace LibraryMS.Services.Membership.Infrastructure.Data;

public class DbInitializer(MembershipDbContext db,
    IUnitOfWork unitOfWork) : IDbInitializer
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly MembershipDbContext _db = db;

    public async Task InitializeAsync()
    {
        try
        {
            // Migrate database changes
            if (_db.Database.GetPendingMigrations().Any())
            {
                await _db.Database.MigrateAsync();
            }

            // Check if the "Basic" membership type is not found, if not, create membership types 
            if (!await _unitOfWork.MembershipType.AnyAsync(
                mt => mt.Name == SD.MembershipTypeBasic))
            {
                // create membership types
                await _unitOfWork.MembershipType.AddAsync(new()
                {
                    Name = SD.MembershipTypeBasic,
                    MaxBooksAllowed = SD.maxBooksAllowedForBasic,
                    MembershipFee = SD.membershipFeeForBasic
                });
                await _unitOfWork.MembershipType.AddAsync(new()
                {
                    Name = SD.MembershipTypeTrial,
                    MaxBooksAllowed = SD.maxBooksAllowedForTrial,
                    MembershipFee = SD.membershipFeeForBasic
                });
                await _unitOfWork.MembershipType.AddAsync(new()
                {
                    Name = SD.MembershipTypePremium,
                    MaxBooksAllowed = SD.maxBooksAllowedForPremium,
                    MembershipFee = SD.membershipFeeForPremium
                });

                await _unitOfWork.SaveAsync();
            }
        }
        catch (Exception ex)
        {
            // Handle or log the exception
            throw new Exception("Error initializing the database", ex);
        }
    }
}