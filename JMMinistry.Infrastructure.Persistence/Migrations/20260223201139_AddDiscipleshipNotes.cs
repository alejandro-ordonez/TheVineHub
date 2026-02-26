using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JMMinistry.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDiscipleshipNotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiscipleshipNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Categories = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DiscipleId = table.Column<string>(type: "text", nullable: false),
                    LeaderId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscipleshipNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscipleshipNotes_PersonalInfo_DiscipleId",
                        column: x => x.DiscipleId,
                        principalTable: "PersonalInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiscipleshipNotes_PersonalInfo_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "PersonalInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscipleshipNotes_DiscipleId",
                table: "DiscipleshipNotes",
                column: "DiscipleId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscipleshipNotes_LeaderId",
                table: "DiscipleshipNotes",
                column: "LeaderId");

            migrationBuilder.Sql(@"
CREATE OR REPLACE FUNCTION is_leader_in_hierarchy(requestor_id TEXT, disciple_id TEXT)
RETURNS BOOLEAN AS $$
DECLARE
    disciple_cell_id INT;
BEGIN
    SELECT ""CellId"" INTO disciple_cell_id
    FROM ""PersonalInfo""
    WHERE ""Id"" = disciple_id;

    IF disciple_cell_id IS NULL THEN
        RETURN FALSE;
    END IF;

    RETURN EXISTS (
        WITH RECURSIVE cell_hierarchy AS (
            -- Base case: leaders of the disciple's cell
            SELECT cpi.""CellsId"" AS cell_id, cpi.""LeadersId"" AS leader_id
            FROM ""CellPersonalInfo"" cpi
            WHERE cpi.""CellsId"" = disciple_cell_id

            UNION

            -- Recursive case: for each leader found, get their cell, then that cell's leaders
            SELECT cpi.""CellsId"", cpi.""LeadersId""
            FROM cell_hierarchy ch
            INNER JOIN ""PersonalInfo"" pi ON pi.""Id"" = ch.leader_id
            INNER JOIN ""CellPersonalInfo"" cpi ON cpi.""CellsId"" = pi.""CellId""
        )
        SELECT 1 FROM cell_hierarchy WHERE leader_id = requestor_id
    );
END;
$$ LANGUAGE plpgsql;
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS is_leader_in_hierarchy(TEXT, TEXT);");

            migrationBuilder.DropTable(
                name: "DiscipleshipNotes");
        }
    }
}
