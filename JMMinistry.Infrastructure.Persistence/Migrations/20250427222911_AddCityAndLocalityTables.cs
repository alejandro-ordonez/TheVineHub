using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JMMinistry.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCityAndLocalityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Locality",
                table: "Cells");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Cells",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "Cells",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocalityId",
                table: "Cells",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CityId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locality", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locality_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cells_CityId",
                table: "Cells",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cells_LocalityId",
                table: "Cells",
                column: "LocalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Locality_CityId",
                table: "Locality",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cells_Cities_CityId",
                table: "Cells",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cells_Locality_LocalityId",
                table: "Cells",
                column: "LocalityId",
                principalTable: "Locality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.DropTable(
                name: "Locality");

            migrationBuilder.DropTable(
                name: "Cities");

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
                name: "Day",
                table: "Cells");

            migrationBuilder.DropColumn(
                name: "LocalityId",
                table: "Cells");

            migrationBuilder.AddColumn<string>(
                name: "Locality",
                table: "Cells",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
