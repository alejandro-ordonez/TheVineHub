using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JMMinistry.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AdjustClassAttendance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CellAttendance_Cells_CellId",
                table: "CellAttendance");

            migrationBuilder.DropForeignKey(
                name: "FK_CellAttendancePersonalInfo_CellAttendance_CellAttendancesId",
                table: "CellAttendancePersonalInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CellAttendance",
                table: "CellAttendance");

            migrationBuilder.RenameTable(
                name: "CellAttendance",
                newName: "CellAttendances");

            migrationBuilder.RenameIndex(
                name: "IX_CellAttendance_CellId",
                table: "CellAttendances",
                newName: "IX_CellAttendances_CellId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CellEnrollmentDate",
                table: "PersonalInfo",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Cells",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Locality",
                table: "Cells",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CellAttendances",
                table: "CellAttendances",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CellAttendancePersonalInfo_CellAttendances_CellAttendancesId",
                table: "CellAttendancePersonalInfo",
                column: "CellAttendancesId",
                principalTable: "CellAttendances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CellAttendances_Cells_CellId",
                table: "CellAttendances",
                column: "CellId",
                principalTable: "Cells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CellAttendancePersonalInfo_CellAttendances_CellAttendancesId",
                table: "CellAttendancePersonalInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_CellAttendances_Cells_CellId",
                table: "CellAttendances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CellAttendances",
                table: "CellAttendances");

            migrationBuilder.DropColumn(
                name: "CellEnrollmentDate",
                table: "PersonalInfo");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Cells");

            migrationBuilder.DropColumn(
                name: "Locality",
                table: "Cells");

            migrationBuilder.RenameTable(
                name: "CellAttendances",
                newName: "CellAttendance");

            migrationBuilder.RenameIndex(
                name: "IX_CellAttendances_CellId",
                table: "CellAttendance",
                newName: "IX_CellAttendance_CellId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CellAttendance",
                table: "CellAttendance",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CellAttendance_Cells_CellId",
                table: "CellAttendance",
                column: "CellId",
                principalTable: "Cells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CellAttendancePersonalInfo_CellAttendance_CellAttendancesId",
                table: "CellAttendancePersonalInfo",
                column: "CellAttendancesId",
                principalTable: "CellAttendance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
