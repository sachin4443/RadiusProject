using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Radius.API.Migrations
{
    /// <inheritdoc />
    public partial class AddPackagesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    PackageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DownSpeed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpSpeed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataLimit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UptimeLimit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationLimit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    PublishToWeb = table.Column<bool>(type: "bit", nullable: false),
                    TaxIncluded = table.Column<bool>(type: "bit", nullable: false),
                    ShowInUcp = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Packages");
        }
    }
}
