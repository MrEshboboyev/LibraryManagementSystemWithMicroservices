﻿// <auto-generated />
using System;
using LibraryMS.Services.Membership.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LibraryMS.Services.Membership.Infrastructure.Data.Migrations
{
    [DbContext(typeof(MembershipDbContext))]
    [Migration("20241029051521_removeLoanHistoryEntity")]
    partial class removeLoanHistoryEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LibraryMS.Services.Membership.Domain.Entities.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("timestamp");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("timestamp");

                    b.Property<Guid>("MembershipTypeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MembershipTypeId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("LibraryMS.Services.Membership.Domain.Entities.MembershipType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("MaxBooksAllowed")
                        .HasColumnType("integer");

                    b.Property<decimal>("MembershipFee")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("MembershipTypes");
                });

            modelBuilder.Entity("LibraryMS.Services.Membership.Domain.Entities.Member", b =>
                {
                    b.HasOne("LibraryMS.Services.Membership.Domain.Entities.MembershipType", "MembershipType")
                        .WithMany("Members")
                        .HasForeignKey("MembershipTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("MembershipType");
                });

            modelBuilder.Entity("LibraryMS.Services.Membership.Domain.Entities.MembershipType", b =>
                {
                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
