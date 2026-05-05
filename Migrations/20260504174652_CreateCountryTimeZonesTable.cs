using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Radius.API.Migrations
{
    /// <inheritdoc />
    public partial class CreateCountryTimeZonesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryTimeZones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TimeZoneId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TimeZoneName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    UtcOffset = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTimeZones", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryTimeZones");
        }
    }
}
