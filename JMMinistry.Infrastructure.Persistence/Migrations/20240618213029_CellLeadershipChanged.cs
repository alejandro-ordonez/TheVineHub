using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JMMinistry.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CellLeadershipChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cells_PersonalInfo_LeaderId",
                table: "Cells");

            migrationBuilder.DropIndex(
                name: "IX_Cells_LeaderId",
                table: "Cells");

            migrationBuilder.DropColumn(
                name: "LeaderId",
                table: "Cells");

            migrationBuilder.RenameColumn(
                name: "CellId",
                table: "Cells",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cells",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CellPersonalInfo",
                columns: table => new
                {
                    CellsId = table.Column<int>(type: "integer", nullable: false),
                    LeadersId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CellPersonalInfo", x => new { x.CellsId, x.LeadersId });
                    table.ForeignKey(
                        name: "FK_CellPersonalInfo_Cells_CellsId",
                        column: x => x.CellsId,
                        principalTable: "Cells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CellPersonalInfo_PersonalInfo_LeadersId",
                        column: x => x.LeadersId,
                        principalTable: "PersonalInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CellPersonalInfo_LeadersId",
                table: "CellPersonalInfo",
                column: "LeadersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CellPersonalInfo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cells",
                newName: "CellId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cells",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "LeaderId",
                table: "Cells",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Cells_LeaderId",
                table: "Cells",
                column: "LeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cells_PersonalInfo_LeaderId",
                table: "Cells",
                column: "LeaderId",
                principalTable: "PersonalInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
