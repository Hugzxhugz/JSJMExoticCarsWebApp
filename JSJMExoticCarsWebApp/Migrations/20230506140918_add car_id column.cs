using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JSJMExoticCarsWebApp.Migrations
{
    /// <inheritdoc />
    public partial class addcar_idcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CarTable",
                newName: "Car_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Car_id",
                table: "CarTable",
                newName: "Id");
        }
    }
}
