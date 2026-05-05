using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Radius.API.Migrations
{
    /// <inheritdoc />
    public partial class levelid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyID",
                table: "CpanlAdminSite",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LevelID",
                table: "CpanlAdminSite",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "CpanlAdminSite");

            migrationBuilder.DropColumn(
                name: "LevelID",
                table: "CpanlAdminSite");
        }
    }
}
