using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoronaStatsAustria.Migrations
{
    /// <inheritdoc />
    public partial class MigrationWithout7Days : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SevenDaysIncidence",
                table: "CovidStatistics");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SevenDaysIncidence",
                table: "CovidStatistics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
