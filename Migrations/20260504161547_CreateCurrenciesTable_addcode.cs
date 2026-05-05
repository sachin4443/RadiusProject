using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Radius.API.Migrations
{
    /// <inheritdoc />
    public partial class CreateCurrenciesTable_addcode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "Currencies");
        }
    }
}
