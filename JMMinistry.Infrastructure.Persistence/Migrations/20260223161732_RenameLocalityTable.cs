using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JMMinistry.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenameLocalityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cells_Locality_LocalityId",
                table: "Cells");

            migrationBuilder.DropForeignKey(
                name: "FK_Locality_Cities_CityId",
                table: "Locality");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locality",
                table: "Locality");

            migrationBuilder.RenameTable(
                name: "Locality",
                newName: "Localities");

            migrationBuilder.RenameIndex(
                name: "IX_Locality_CityId",
                table: "Localities",
                newName: "IX_Localities_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Localities",
                table: "Localities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cells_Localities_LocalityId",
                table: "Cells",
                column: "LocalityId",
                principalTable: "Localities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Localities_Cities_CityId",
                table: "Localities",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cells_Localities_LocalityId",
                table: "Cells");

            migrationBuilder.DropForeignKey(
                name: "FK_Localities_Cities_CityId",
                table: "Localities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Localities",
                table: "Localities");

            migrationBuilder.RenameTable(
                name: "Localities",
                newName: "Locality");

            migrationBuilder.RenameIndex(
                name: "IX_Localities_CityId",
                table: "Locality",
                newName: "IX_Locality_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locality",
                table: "Locality",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cells_Locality_LocalityId",
                table: "Cells",
                column: "LocalityId",
                principalTable: "Locality",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locality_Cities_CityId",
                table: "Locality",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");
        }
    }
}
