using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JSJMExoticCarsWebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    car_model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    car_brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    car_model_year = table.Column<int>(type: "int", nullable: false),
                    car_milage = table.Column<int>(type: "int", nullable: false),
                    car_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    car_image_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    car_transmission = table.Column<int>(type: "int", nullable: false),
                    car_fueltype = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarTable", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarTable");
        }
    }
}
