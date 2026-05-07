using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Radius.API.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingFieldsInCpanlAdminSite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BusinessType",
                table: "CpanlAdminSite",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyTagline",
                table: "CpanlAdminSite",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsEnabled",
                table: "CpanlAdminSite",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "CpanlAdminSite",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "CpanlAdminSite",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "CpanlAdminSite",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SiteDescription",
                table: "CpanlAdminSite",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SiteDomain",
                table: "CpanlAdminSite",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SiteEmail",
                table: "CpanlAdminSite",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SiteMobileNo",
                table: "CpanlAdminSite",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UseOwnDomain",
                table: "CpanlAdminSite",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessType",
                table: "CpanlAdminSite");

            migrationBuilder.DropColumn(
                name: "CompanyTagline",
                table: "CpanlAdminSite");

            migrationBuilder.DropColumn(
                name: "IsEnabled",
                table: "CpanlAdminSite");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "CpanlAdminSite");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "CpanlAdminSite");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "CpanlAdminSite");

            migrationBuilder.DropColumn(
                name: "SiteDescription",
                table: "CpanlAdminSite");

            migrationBuilder.DropColumn(
                name: "SiteDomain",
                table: "CpanlAdminSite");

            migrationBuilder.DropColumn(
                name: "SiteEmail",
                table: "CpanlAdminSite");

            migrationBuilder.DropColumn(
                name: "SiteMobileNo",
                table: "CpanlAdminSite");

            migrationBuilder.DropColumn(
                name: "UseOwnDomain",
                table: "CpanlAdminSite");
        }
    }
}
