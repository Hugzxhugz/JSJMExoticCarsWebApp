using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JSJMExoticCarsWebApp.Migrations
{
    /// <inheritdoc />
    public partial class cardbcomplete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "car_listed",
                table: "CarTable",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "car_price",
                table: "CarTable",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "car_listed",
                table: "CarTable");

            migrationBuilder.DropColumn(
                name: "car_price",
                table: "CarTable");
        }
    }
}
