using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JMMinistry.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddsExtraPersonalInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PersonalInfo_Document",
                table: "PersonalInfo");

            migrationBuilder.DropColumn(
                name: "Document",
                table: "PersonalInfo");

            migrationBuilder.AddColumn<int>(
                name: "EducationalLevel",
                table: "PersonalInfo",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatus",
                table: "PersonalInfo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                table: "PersonalInfo",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profession",
                table: "PersonalInfo",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Cells",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EducationalLevel",
                table: "PersonalInfo");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "PersonalInfo");

            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "PersonalInfo");

            migrationBuilder.DropColumn(
                name: "Profession",
                table: "PersonalInfo");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Cells");

            migrationBuilder.AddColumn<string>(
                name: "Document",
                table: "PersonalInfo",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInfo_Document",
                table: "PersonalInfo",
                column: "Document",
                unique: true);
        }
    }
}
