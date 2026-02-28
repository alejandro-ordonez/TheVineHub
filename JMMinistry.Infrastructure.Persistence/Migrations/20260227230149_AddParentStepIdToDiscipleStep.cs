using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JMMinistry.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddParentStepIdToDiscipleStep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentStepId",
                table: "DiscipleSteps",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DiscipleSteps_ParentStepId",
                table: "DiscipleSteps",
                column: "ParentStepId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscipleSteps_DiscipleSteps_ParentStepId",
                table: "DiscipleSteps",
                column: "ParentStepId",
                principalTable: "DiscipleSteps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscipleSteps_DiscipleSteps_ParentStepId",
                table: "DiscipleSteps");

            migrationBuilder.DropIndex(
                name: "IX_DiscipleSteps_ParentStepId",
                table: "DiscipleSteps");

            migrationBuilder.DropColumn(
                name: "ParentStepId",
                table: "DiscipleSteps");
        }
    }
}
