using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JMMinistry.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDiscipleStepsAndRequirements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                ALTER TABLE IF EXISTS "PersonalInfo" DROP CONSTRAINT IF EXISTS "FK_PersonalInfo_Gained_GainedId";
                DROP TABLE IF EXISTS "GainedEvent";
                DROP TABLE IF EXISTS "Gained";
                DROP INDEX IF EXISTS "IX_PersonalInfo_GainedId";
                ALTER TABLE "PersonalInfo" DROP COLUMN IF EXISTS "GainedId";
                ALTER TABLE "PersonalInfo" DROP COLUMN IF EXISTS "MinistryStatus";
                """);

            migrationBuilder.CreateTable(
                name: "DiscipleSteps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    StepCategory = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscipleSteps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscipleStepRequirement",
                columns: table => new
                {
                    DiscipleStepId = table.Column<int>(type: "integer", nullable: false),
                    DiscipleStepRequirementsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscipleStepRequirement", x => new { x.DiscipleStepId, x.DiscipleStepRequirementsId });
                    table.ForeignKey(
                        name: "FK_DiscipleStepRequirement_DiscipleSteps_DiscipleStepId",
                        column: x => x.DiscipleStepId,
                        principalTable: "DiscipleSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscipleStepRequirement_DiscipleSteps_DiscipleStepRequireme~",
                        column: x => x.DiscipleStepRequirementsId,
                        principalTable: "DiscipleSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StepCompletions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreated = table.Column<DateOnly>(type: "date", nullable: false),
                    LastUpdated = table.Column<DateOnly>(type: "date", nullable: false),
                    StepStatus = table.Column<int>(type: "integer", nullable: false),
                    DiscipleStepId = table.Column<int>(type: "integer", nullable: false),
                    DiscipleId = table.Column<string>(type: "text", nullable: false),
                    LeaderId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepCompletions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StepCompletions_DiscipleSteps_DiscipleStepId",
                        column: x => x.DiscipleStepId,
                        principalTable: "DiscipleSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StepCompletions_PersonalInfo_DiscipleId",
                        column: x => x.DiscipleId,
                        principalTable: "PersonalInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StepCompletions_PersonalInfo_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "PersonalInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscipleStepRequirement_DiscipleStepRequirementsId",
                table: "DiscipleStepRequirement",
                column: "DiscipleStepRequirementsId");

            migrationBuilder.CreateIndex(
                name: "IX_StepCompletions_DiscipleId",
                table: "StepCompletions",
                column: "DiscipleId");

            migrationBuilder.CreateIndex(
                name: "IX_StepCompletions_DiscipleStepId",
                table: "StepCompletions",
                column: "DiscipleStepId");

            migrationBuilder.CreateIndex(
                name: "IX_StepCompletions_LeaderId",
                table: "StepCompletions",
                column: "LeaderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscipleStepRequirement");

            migrationBuilder.DropTable(
                name: "StepCompletions");

            migrationBuilder.DropTable(
                name: "DiscipleSteps");

            migrationBuilder.AddColumn<int>(
                name: "GainedId",
                table: "PersonalInfo",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinistryStatus",
                table: "PersonalInfo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Gained",
                columns: table => new
                {
                    GainedId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvitedById = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    PersonId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gained", x => x.GainedId);
                    table.ForeignKey(
                        name: "FK_Gained_PersonalInfo_InvitedById",
                        column: x => x.InvitedById,
                        principalTable: "PersonalInfo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GainedEvent",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GainedId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    EventType = table.Column<int>(type: "integer", nullable: false),
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
                name: "IX_PersonalInfo_GainedId",
                table: "PersonalInfo",
                column: "GainedId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gained_InvitedById",
                table: "Gained",
                column: "InvitedById");

            migrationBuilder.CreateIndex(
                name: "IX_GainedEvent_GainedId",
                table: "GainedEvent",
                column: "GainedId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInfo_Gained_GainedId",
                table: "PersonalInfo",
                column: "GainedId",
                principalTable: "Gained",
                principalColumn: "GainedId");
        }
    }
}
