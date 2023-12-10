using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SurveySystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kpis",
                columns: table => new
                {
                    KPINum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KPIDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepNo = table.Column<int>(type: "int", nullable: false),
                    MeasurementUnit = table.Column<bool>(type: "bit", nullable: false),
                    TargetedValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kpis", x => x.KPINum);
                });

            migrationBuilder.InsertData(
                table: "Kpis",
                columns: new[] { "KPINum", "DepNo", "KPIDescription", "MeasurementUnit", "TargetedValue" },
                values: new object[,]
                {
                    { 18320088, 1, "Increase Net Promoter Score 25% over the next three years", false, 80 },
                    { 18820007, 2, "Grow sales by 5% per quarter", true, 100 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kpis");
        }
    }
}
