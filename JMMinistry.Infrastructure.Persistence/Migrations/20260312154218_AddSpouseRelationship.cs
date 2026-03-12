using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JMMinistry.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSpouseRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpouseId",
                table: "PersonalInfo",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInfo_SpouseId",
                table: "PersonalInfo",
                column: "SpouseId",
                unique: true,
                filter: "\"SpouseId\" IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInfo_PersonalInfo_SpouseId",
                table: "PersonalInfo",
                column: "SpouseId",
                principalTable: "PersonalInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInfo_PersonalInfo_SpouseId",
                table: "PersonalInfo");

            migrationBuilder.DropIndex(
                name: "IX_PersonalInfo_SpouseId",
                table: "PersonalInfo");

            migrationBuilder.DropColumn(
                name: "SpouseId",
                table: "PersonalInfo");
        }
    }
}
