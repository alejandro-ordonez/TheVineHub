using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JMMinistry.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddStepCycles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StepCycleId",
                table: "StepCompletions",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequiresCycle",
                table: "DiscipleSteps",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "StepCycles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    MinAttendanceRequired = table.Column<int>(type: "integer", nullable: false),
                    IsOpen = table.Column<bool>(type: "boolean", nullable: false),
                    EnrollmentDeadline = table.Column<DateOnly>(type: "date", nullable: true),
                    DiscipleStepId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepCycles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StepCycles_DiscipleSteps_DiscipleStepId",
                        column: x => x.DiscipleStepId,
                        principalTable: "DiscipleSteps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CycleSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Topic = table.Column<string>(type: "text", nullable: true),
                    StepCycleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CycleSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CycleSessions_StepCycles_StepCycleId",
                        column: x => x.StepCycleId,
                        principalTable: "StepCycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CycleStaff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    StepCycleId = table.Column<int>(type: "integer", nullable: false),
                    PersonId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CycleStaff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CycleStaff_PersonalInfo_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonalInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CycleStaff_StepCycles_StepCycleId",
                        column: x => x.StepCycleId,
                        principalTable: "StepCycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CycleAttendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CycleSessionId = table.Column<int>(type: "integer", nullable: false),
                    DiscipleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CycleAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CycleAttendances_CycleSessions_CycleSessionId",
                        column: x => x.CycleSessionId,
                        principalTable: "CycleSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CycleAttendances_PersonalInfo_DiscipleId",
                        column: x => x.DiscipleId,
                        principalTable: "PersonalInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CycleEnrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    EnrolledAt = table.Column<DateOnly>(type: "date", nullable: false),
                    StepCycleId = table.Column<int>(type: "integer", nullable: false),
                    DiscipleId = table.Column<string>(type: "text", nullable: false),
                    CycleStaffId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CycleEnrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CycleEnrollments_CycleStaff_CycleStaffId",
                        column: x => x.CycleStaffId,
                        principalTable: "CycleStaff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_CycleEnrollments_PersonalInfo_DiscipleId",
                        column: x => x.DiscipleId,
                        principalTable: "PersonalInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CycleEnrollments_StepCycles_StepCycleId",
                        column: x => x.StepCycleId,
                        principalTable: "StepCycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StepCompletions_StepCycleId",
                table: "StepCompletions",
                column: "StepCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_CycleAttendances_CycleSessionId_DiscipleId",
                table: "CycleAttendances",
                columns: new[] { "CycleSessionId", "DiscipleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CycleAttendances_DiscipleId",
                table: "CycleAttendances",
                column: "DiscipleId");

            migrationBuilder.CreateIndex(
                name: "IX_CycleEnrollments_CycleStaffId",
                table: "CycleEnrollments",
                column: "CycleStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_CycleEnrollments_DiscipleId",
                table: "CycleEnrollments",
                column: "DiscipleId");

            migrationBuilder.CreateIndex(
                name: "IX_CycleEnrollments_StepCycleId_DiscipleId",
                table: "CycleEnrollments",
                columns: new[] { "StepCycleId", "DiscipleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CycleSessions_StepCycleId",
                table: "CycleSessions",
                column: "StepCycleId");

            migrationBuilder.CreateIndex(
                name: "IX_CycleStaff_PersonId",
                table: "CycleStaff",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_CycleStaff_StepCycleId_PersonId",
                table: "CycleStaff",
                columns: new[] { "StepCycleId", "PersonId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StepCycles_DiscipleStepId",
                table: "StepCycles",
                column: "DiscipleStepId");

            migrationBuilder.CreateIndex(
                name: "IX_StepCycles_DiscipleStepId_IsOpen",
                table: "StepCycles",
                columns: new[] { "DiscipleStepId", "IsOpen" });

            migrationBuilder.AddForeignKey(
                name: "FK_StepCompletions_StepCycles_StepCycleId",
                table: "StepCompletions",
                column: "StepCycleId",
                principalTable: "StepCycles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StepCompletions_StepCycles_StepCycleId",
                table: "StepCompletions");

            migrationBuilder.DropTable(
                name: "CycleAttendances");

            migrationBuilder.DropTable(
                name: "CycleEnrollments");

            migrationBuilder.DropTable(
                name: "CycleSessions");

            migrationBuilder.DropTable(
                name: "CycleStaff");

            migrationBuilder.DropTable(
                name: "StepCycles");

            migrationBuilder.DropIndex(
                name: "IX_StepCompletions_StepCycleId",
                table: "StepCompletions");

            migrationBuilder.DropColumn(
                name: "StepCycleId",
                table: "StepCompletions");

            migrationBuilder.DropColumn(
                name: "RequiresCycle",
                table: "DiscipleSteps");
        }
    }
}
