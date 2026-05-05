using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Radius.API.Migrations
{
    /// <inheritdoc />
    public partial class AddDropdownFieldsInCpanlAdminSite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "CpanlAdminSite",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "CpanlAdminSite",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeZoneId",
                table: "CpanlAdminSite",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "CpanlAdminSite");

            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "CpanlAdminSite");

            migrationBuilder.DropColumn(
                name: "TimeZoneId",
                table: "CpanlAdminSite");
        }
    }
}
