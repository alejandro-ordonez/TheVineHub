using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JMMinistry.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ColumnsChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gaineds_PersonalInfo_InvitedById",
                table: "Gaineds");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInfo_Gaineds_GainedId",
                table: "PersonalInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gaineds",
                table: "Gaineds");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "ClassNumber",
                table: "Classes");

            migrationBuilder.RenameTable(
                name: "Gaineds",
                newName: "Gained");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Classes",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "DateRecorded",
                table: "ClassAttendances",
                newName: "DateOfClass");

            migrationBuilder.RenameIndex(
                name: "IX_Gaineds_InvitedById",
                table: "Gained",
                newName: "IX_Gained_InvitedById");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Schools",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Schools",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "PersonalInfo",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinistryStatus",
                table: "PersonalInfo",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Classes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Classes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Classes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ClassNumber",
                table: "ClassAttendances",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ClassRefName",
                table: "ClassAttendances",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gained",
                table: "Gained",
                column: "GainedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gained_PersonalInfo_InvitedById",
                table: "Gained",
                column: "InvitedById",
                principalTable: "PersonalInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInfo_Gained_GainedId",
                table: "PersonalInfo",
                column: "GainedId",
                principalTable: "Gained",
                principalColumn: "GainedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gained_PersonalInfo_InvitedById",
                table: "Gained");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInfo_Gained_GainedId",
                table: "PersonalInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gained",
                table: "Gained");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "PersonalInfo");

            migrationBuilder.DropColumn(
                name: "MinistryStatus",
                table: "PersonalInfo");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "ClassNumber",
                table: "ClassAttendances");

            migrationBuilder.DropColumn(
                name: "ClassRefName",
                table: "ClassAttendances");

            migrationBuilder.RenameTable(
                name: "Gained",
                newName: "Gaineds");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Classes",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "DateOfClass",
                table: "ClassAttendances",
                newName: "DateRecorded");

            migrationBuilder.RenameIndex(
                name: "IX_Gained_InvitedById",
                table: "Gaineds",
                newName: "IX_Gaineds_InvitedById");

            migrationBuilder.AddColumn<DateOnly>(
                name: "EndDate",
                table: "Schools",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "StartDate",
                table: "Schools",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "Classes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassNumber",
                table: "Classes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gaineds",
                table: "Gaineds",
                column: "GainedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gaineds_PersonalInfo_InvitedById",
                table: "Gaineds",
                column: "InvitedById",
                principalTable: "PersonalInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalInfo_Gaineds_GainedId",
                table: "PersonalInfo",
                column: "GainedId",
                principalTable: "Gaineds",
                principalColumn: "GainedId");
        }
    }
}
