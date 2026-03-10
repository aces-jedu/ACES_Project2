using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ACES_Project2.Migrations
{
    /// <inheritdoc />
    public partial class applicationuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add new columns to AspNetUsers table
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LoginAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LogoutAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove all added columns if rolling back
            migrationBuilder.DropColumn(name: "FirstName", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "MiddleName", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "LastName", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "DateOfBirth", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "Gender", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "CreatedAt", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "LoginAt", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "LogoutAt", table: "AspNetUsers");
            migrationBuilder.DropColumn(name: "IsActive", table: "AspNetUsers");
        }
    }
}