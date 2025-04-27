using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JMMinistry.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class GainedUsersRefactored : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contacted",
                table: "Gained");

            migrationBuilder.DropColumn(
                name: "InACell",
                table: "Gained");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Gained");

            migrationBuilder.CreateTable(
                name: "GainedEvent",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GainedId = table.Column<int>(type: "integer", nullable: false),
                    EventType = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Observations = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GainedEvent", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_GainedEvent_Gained_GainedId",
                        column: x => x.GainedId,
                        principalTable: "Gained",
                        principalColumn: "GainedId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GainedEvent_GainedId",
                table: "GainedEvent",
                column: "GainedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GainedEvent");

            migrationBuilder.AddColumn<bool>(
                name: "Contacted",
                table: "Gained",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InACell",
                table: "Gained",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Gained",
                type: "text",
                nullable: true);
        }
    }
}
