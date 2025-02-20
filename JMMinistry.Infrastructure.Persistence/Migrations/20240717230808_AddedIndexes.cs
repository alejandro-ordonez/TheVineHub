using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JMMinistry.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Document",
                table: "PersonalInfo",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "PersonalInfo",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInfo_Document",
                table: "PersonalInfo",
                column: "Document",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInfo_Name_LastName",
                table: "PersonalInfo",
                columns: new[] { "Name", "LastName" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PersonalInfo_Document",
                table: "PersonalInfo");

            migrationBuilder.DropIndex(
                name: "IX_PersonalInfo_Name_LastName",
                table: "PersonalInfo");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "PersonalInfo");

            migrationBuilder.AlterColumn<string>(
                name: "Document",
                table: "PersonalInfo",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
