using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JMMinistry.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCellsToCityAndLocality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Cells",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocalityId",
                table: "Cells",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cells_CityId",
                table: "Cells",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cells_LocalityId",
                table: "Cells",
                column: "LocalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cells_Cities_CityId",
                table: "Cells",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Cells_Locality_LocalityId",
                table: "Cells",
                column: "LocalityId",
                principalTable: "Locality",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cells_Cities_CityId",
                table: "Cells");

            migrationBuilder.DropForeignKey(
                name: "FK_Cells_Locality_LocalityId",
                table: "Cells");

            migrationBuilder.DropIndex(
                name: "IX_Cells_CityId",
                table: "Cells");

            migrationBuilder.DropIndex(
                name: "IX_Cells_LocalityId",
                table: "Cells");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Cells");

            migrationBuilder.DropColumn(
                name: "LocalityId",
                table: "Cells");
        }
    }
}
