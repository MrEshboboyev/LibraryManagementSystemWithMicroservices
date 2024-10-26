using LibraryMS.Services.Membership.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryMS.Services.Membership.Infrastructure.Data;

public class MembershipDbContext(DbContextOptions<MembershipDbContext> options) : DbContext(options)
{
    public DbSet<Member> Members { get; set; }
    public DbSet<MembershipType> MembershipTypes { get; set; }
    public DbSet<LoanHistory> LoanHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuring MembershipType
        modelBuilder.Entity<MembershipType>()
            .HasKey(mt => mt.Id);

        modelBuilder.Entity<MembershipType>()
            .Property(mt => mt.Name)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<MembershipType>()
            .HasMany(mt => mt.Members)
            .WithOne(m => m.MembershipType)
            .HasForeignKey(m => m.MembershipTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configuring Member
        modelBuilder.Entity<Member>()
            .HasKey(m => m.Id);

        modelBuilder.Entity<Member>()
            .Property(m => m.AppUserId)
            .IsRequired();

        //modelBuilder.Entity<Member>()
        //    .Property(m => m.JoinDate)
        //    .HasColumnType("timestamp");

        //modelBuilder.Entity<Member>()
        //    .Property(m => m.ExpirationDate)
        //    .HasColumnType("timestamp");

        modelBuilder.Entity<Member>()
            .HasMany(m => m.LoanHistories)
            .WithOne(lh => lh.Member)
            .HasForeignKey(lh => lh.MemberId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configuring LoanHistory
        modelBuilder.Entity<LoanHistory>()
            .HasKey(lh => lh.Id);

        //modelBuilder.Entity<LoanHistory>()
        //    .Property(lh => lh.BorrowedDate)
        //    .HasColumnType("timestamp");

        //modelBuilder.Entity<LoanHistory>()
        //    .Property(lh => lh.ReturnedDate)
        //    .HasColumnType("timestamp")
        //    .IsRequired(false);

        // Additional Indexes and Constraints (if needed)
        modelBuilder.Entity<LoanHistory>()
            .HasIndex(lh => new { lh.BookId, lh.MemberId });
    }
}

