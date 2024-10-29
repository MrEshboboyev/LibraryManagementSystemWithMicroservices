using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryMS.Services.Membership.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class removeLoanHistoryEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanHistories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinDate",
                table: "Members",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "Members",
                type: "timestamp",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinDate",
                table: "Members",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "Members",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "LoanHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MemberId = table.Column<Guid>(type: "uuid", nullable: false),
                    BookId = table.Column<Guid>(type: "uuid", nullable: false),
                    BorrowedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReturnedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanHistories_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanHistories_BookId_MemberId",
                table: "LoanHistories",
                columns: new[] { "BookId", "MemberId" });

            migrationBuilder.CreateIndex(
                name: "IX_LoanHistories_MemberId",
                table: "LoanHistories",
                column: "MemberId");
        }
    }
}
