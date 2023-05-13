using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JSJMExoticCarsWebApp.Migrations
{
    /// <inheritdoc />
    public partial class completedatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_funds = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarTable",
                columns: table => new
                {
                    car_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    car_model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    car_brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    car_model_year = table.Column<int>(type: "int", nullable: false),
                    car_milage = table.Column<int>(type: "int", nullable: false),
                    car_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    car_image_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    car_transmission = table.Column<int>(type: "int", nullable: false),
                    car_fueltype = table.Column<int>(type: "int", nullable: false),
                    car_listed = table.Column<bool>(type: "bit", nullable: false),
                    car_price = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarTable", x => x.car_id);
                    table.ForeignKey(
                        name: "FK_CarTable_UsersTable_UserId",
                        column: x => x.UserId,
                        principalTable: "UsersTable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarTable_UserId",
                table: "CarTable",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarTable");

            migrationBuilder.DropTable(
                name: "UsersTable");
        }
    }
}
