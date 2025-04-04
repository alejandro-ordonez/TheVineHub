using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JMMinistry.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class IndependentMeetingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetingAttendances_PersonalInfo_PersonId",
                table: "MeetingAttendances");

            migrationBuilder.DropIndex(
                name: "IX_MeetingAttendances_PersonId",
                table: "MeetingAttendances");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "MeetingAttendances");

            migrationBuilder.RenameColumn(
                name: "MeetingType",
                table: "MeetingAttendances",
                newName: "MeetingId");

            migrationBuilder.CreateTable(
                name: "MeetingAttendancePersonalInfo",
                columns: table => new
                {
                    AttendeesId = table.Column<string>(type: "text", nullable: false),
                    MeetingAttendancesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingAttendancePersonalInfo", x => new { x.AttendeesId, x.MeetingAttendancesId });
                    table.ForeignKey(
                        name: "FK_MeetingAttendancePersonalInfo_MeetingAttendances_MeetingAtt~",
                        column: x => x.MeetingAttendancesId,
                        principalTable: "MeetingAttendances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingAttendancePersonalInfo_PersonalInfo_AttendeesId",
                        column: x => x.AttendeesId,
                        principalTable: "PersonalInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    End = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsRecurrent = table.Column<bool>(type: "boolean", nullable: false),
                    DayOfWeek = table.Column<int>(type: "integer", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: true),
                    MeetingType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeetingAttendances_MeetingId",
                table: "MeetingAttendances",
                column: "MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingAttendancePersonalInfo_MeetingAttendancesId",
                table: "MeetingAttendancePersonalInfo",
                column: "MeetingAttendancesId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingAttendances_Meetings_MeetingId",
                table: "MeetingAttendances",
                column: "MeetingId",
                principalTable: "Meetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetingAttendances_Meetings_MeetingId",
                table: "MeetingAttendances");

            migrationBuilder.DropTable(
                name: "MeetingAttendancePersonalInfo");

            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropIndex(
                name: "IX_MeetingAttendances_MeetingId",
                table: "MeetingAttendances");

            migrationBuilder.RenameColumn(
                name: "MeetingId",
                table: "MeetingAttendances",
                newName: "MeetingType");

            migrationBuilder.AddColumn<string>(
                name: "PersonId",
                table: "MeetingAttendances",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeetingAttendances_PersonId",
                table: "MeetingAttendances",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingAttendances_PersonalInfo_PersonId",
                table: "MeetingAttendances",
                column: "PersonId",
                principalTable: "PersonalInfo",
                principalColumn: "Id");
        }
    }
}
