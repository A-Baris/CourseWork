using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CA_VehicleDB_CodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class updatedValids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TireId",
                table: "Motorcycles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TireId",
                table: "Automobiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Automobiles",
                columns: new[] { "Id", "Colour", "EngineId", "Fuel", "MaxKmh", "TireId", "TransmissionType" },
                values: new object[,]
                {
                    { 1, "White", 1, "Diesel", 260, 1, "M" },
                    { 2, "Black", 2, "Gasoline", 280, 1, "A" }
                });

            migrationBuilder.InsertData(
                table: "Motorcycles",
                columns: new[] { "Id", "Colour", "EngineId", "Fuel", "MaxKmh", "TireId", "TransmissionType" },
                values: new object[] { 1, "Red", 1, "Gasoline", 300, 3, "M" });

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_TireId",
                table: "Motorcycles",
                column: "TireId");

            migrationBuilder.CreateIndex(
                name: "IX_Automobiles_TireId",
                table: "Automobiles",
                column: "TireId");

            migrationBuilder.AddForeignKey(
                name: "FK_Automobiles_Tires_TireId",
                table: "Automobiles",
                column: "TireId",
                principalTable: "Tires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_Tires_TireId",
                table: "Motorcycles",
                column: "TireId",
                principalTable: "Tires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Automobiles_Tires_TireId",
                table: "Automobiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_Tires_TireId",
                table: "Motorcycles");

            migrationBuilder.DropIndex(
                name: "IX_Motorcycles_TireId",
                table: "Motorcycles");

            migrationBuilder.DropIndex(
                name: "IX_Automobiles_TireId",
                table: "Automobiles");

            migrationBuilder.DeleteData(
                table: "Automobiles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Automobiles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Motorcycles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "TireId",
                table: "Motorcycles");

            migrationBuilder.DropColumn(
                name: "TireId",
                table: "Automobiles");
        }
    }
}
