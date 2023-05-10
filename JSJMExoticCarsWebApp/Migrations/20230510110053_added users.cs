using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JSJMExoticCarsWebApp.Migrations
{
    /// <inheritdoc />
    public partial class addedusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CarTable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
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
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarTable_UserId",
                table: "CarTable",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarTable_Users_UserId",
                table: "CarTable",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarTable_Users_UserId",
                table: "CarTable");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_CarTable_UserId",
                table: "CarTable");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CarTable");
        }
    }
}
