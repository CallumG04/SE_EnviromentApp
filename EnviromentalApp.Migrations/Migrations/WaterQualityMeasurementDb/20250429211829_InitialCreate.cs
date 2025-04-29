using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnviromentalApp.Database.Migrations.WaterQualityMeasurementDb
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WaterQualityMeasurements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sensorId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NitrateN03 = table.Column<double>(type: "float", nullable: false),
                    NitrateN02 = table.Column<double>(type: "float", nullable: false),
                    Phosphate = table.Column<double>(type: "float", nullable: false),
                    EC = table.Column<double>(type: "float", nullable: false),
                    IE = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterQualityMeasurements", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WaterQualityMeasurements");
        }
    }
}
