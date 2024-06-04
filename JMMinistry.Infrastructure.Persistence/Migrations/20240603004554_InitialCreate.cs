using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JMMinistry.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:meeting_type", "one,rocks,family")
                .Annotation("Npgsql:Enum:member_type", "coordinator,staff,assistant")
                .Annotation("Npgsql:Enum:ministry_status", "guess,gained,consolidating,disciple,leader");

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ministries",
                columns: table => new
                {
                    MinistryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MinistryManagementId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ministries", x => x.MinistryId);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conventions",
                columns: table => new
                {
                    ConventionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    MinistryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conventions", x => x.ConventionId);
                    table.ForeignKey(
                        name: "FK_Conventions_Ministries_MinistryId",
                        column: x => x.MinistryId,
                        principalTable: "Ministries",
                        principalColumn: "MinistryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    MinistryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Ministries_MinistryId",
                        column: x => x.MinistryId,
                        principalTable: "Ministries",
                        principalColumn: "MinistryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SchoolId = table.Column<int>(type: "integer", nullable: true),
                    DateRecorded = table.Column<DateOnly>(type: "date", nullable: false),
                    Student = table.Column<string>(type: "text", nullable: false),
                    Grade = table.Column<decimal>(type: "numeric", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    ClassName = table.Column<string>(type: "text", nullable: true),
                    ClassNumber = table.Column<int>(type: "integer", nullable: false),
                    SchoolId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassAttendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClassId = table.Column<int>(type: "integer", nullable: false),
                    DateRecorded = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassAttendances_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CellAttendance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CellId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CellAttendance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CellAttendancePersonalInfo",
                columns: table => new
                {
                    AttendeesDocument = table.Column<string>(type: "text", nullable: false),
                    CellAttendancesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CellAttendancePersonalInfo", x => new { x.AttendeesDocument, x.CellAttendancesId });
                    table.ForeignKey(
                        name: "FK_CellAttendancePersonalInfo_CellAttendance_CellAttendancesId",
                        column: x => x.CellAttendancesId,
                        principalTable: "CellAttendance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cells",
                columns: table => new
                {
                    CellId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    MainCell = table.Column<bool>(type: "boolean", nullable: false),
                    LeaderId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cells", x => x.CellId);
                });

            migrationBuilder.CreateTable(
                name: "ClassAttendancePersonalInfo",
                columns: table => new
                {
                    AttendeesDocument = table.Column<string>(type: "text", nullable: false),
                    ClassAttendancesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassAttendancePersonalInfo", x => new { x.AttendeesDocument, x.ClassAttendancesId });
                    table.ForeignKey(
                        name: "FK_ClassAttendancePersonalInfo_ClassAttendances_ClassAttendanc~",
                        column: x => x.ClassAttendancesId,
                        principalTable: "ClassAttendances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClassId = table.Column<int>(type: "integer", nullable: true),
                    StudentId = table.Column<string>(type: "text", nullable: false),
                    Paid = table.Column<bool>(type: "boolean", nullable: false),
                    Debt = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassStudents_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConventionAttendees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConventionId = table.Column<int>(type: "integer", nullable: false),
                    AttendeeId = table.Column<string>(type: "text", nullable: false),
                    InvitedById = table.Column<string>(type: "text", nullable: true),
                    Confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    Paid = table.Column<bool>(type: "boolean", nullable: false),
                    Debt = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConventionAttendees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConventionAttendees_Conventions_ConventionId",
                        column: x => x.ConventionId,
                        principalTable: "Conventions",
                        principalColumn: "ConventionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gaineds",
                columns: table => new
                {
                    GainedId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonId = table.Column<string>(type: "text", nullable: false),
                    InvitedById = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Contacted = table.Column<bool>(type: "boolean", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    InACell = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gaineds", x => x.GainedId);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInfos",
                columns: table => new
                {
                    Document = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Lastname = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Locality = table.Column<string>(type: "text", nullable: false),
                    Neighborhood = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: false),
                    GainedId = table.Column<int>(type: "integer", nullable: true),
                    CellId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInfos", x => x.Document);
                    table.ForeignKey(
                        name: "FK_PersonalInfos_Cells_CellId",
                        column: x => x.CellId,
                        principalTable: "Cells",
                        principalColumn: "CellId");
                    table.ForeignKey(
                        name: "FK_PersonalInfos_Gaineds_GainedId",
                        column: x => x.GainedId,
                        principalTable: "Gaineds",
                        principalColumn: "GainedId");
                });

            migrationBuilder.CreateTable(
                name: "MeetingAttendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    MeetingType = table.Column<int>(type: "integer", nullable: false),
                    PersonId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingAttendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeetingAttendances_PersonalInfos_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonalInfos",
                        principalColumn: "Document");
                });

            migrationBuilder.CreateTable(
                name: "MinistryManagements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MinistryId = table.Column<int>(type: "integer", nullable: false),
                    MemberId = table.Column<string>(type: "text", nullable: false),
                    MemberType = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinistryManagements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MinistryManagements_Ministries_MinistryId",
                        column: x => x.MinistryId,
                        principalTable: "Ministries",
                        principalColumn: "MinistryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MinistryManagements_PersonalInfos_MemberId",
                        column: x => x.MemberId,
                        principalTable: "PersonalInfos",
                        principalColumn: "Document",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_SchoolId",
                table: "Assignments",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_CellAttendance_CellId",
                table: "CellAttendance",
                column: "CellId");

            migrationBuilder.CreateIndex(
                name: "IX_CellAttendancePersonalInfo_CellAttendancesId",
                table: "CellAttendancePersonalInfo",
                column: "CellAttendancesId");

            migrationBuilder.CreateIndex(
                name: "IX_Cells_LeaderId",
                table: "Cells",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAttendancePersonalInfo_ClassAttendancesId",
                table: "ClassAttendancePersonalInfo",
                column: "ClassAttendancesId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassAttendances_ClassId",
                table: "ClassAttendances",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_SchoolId",
                table: "Classes",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudents_ClassId",
                table: "ClassStudents",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudents_StudentId",
                table: "ClassStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ConventionAttendees_AttendeeId",
                table: "ConventionAttendees",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ConventionAttendees_ConventionId",
                table: "ConventionAttendees",
                column: "ConventionId");

            migrationBuilder.CreateIndex(
                name: "IX_ConventionAttendees_InvitedById",
                table: "ConventionAttendees",
                column: "InvitedById");

            migrationBuilder.CreateIndex(
                name: "IX_Conventions_MinistryId",
                table: "Conventions",
                column: "MinistryId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_MinistryId",
                table: "Events",
                column: "MinistryId");

            migrationBuilder.CreateIndex(
                name: "IX_Gaineds_InvitedById",
                table: "Gaineds",
                column: "InvitedById");

            migrationBuilder.CreateIndex(
                name: "IX_MeetingAttendances_PersonId",
                table: "MeetingAttendances",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_MinistryManagements_MemberId",
                table: "MinistryManagements",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MinistryManagements_MinistryId",
                table: "MinistryManagements",
                column: "MinistryId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInfos_CellId",
                table: "PersonalInfos",
                column: "CellId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInfos_GainedId",
                table: "PersonalInfos",
                column: "GainedId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CellAttendance_Cells_CellId",
                table: "CellAttendance",
                column: "CellId",
                principalTable: "Cells",
                principalColumn: "CellId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CellAttendancePersonalInfo_PersonalInfos_AttendeesDocument",
                table: "CellAttendancePersonalInfo",
                column: "AttendeesDocument",
                principalTable: "PersonalInfos",
                principalColumn: "Document",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cells_PersonalInfos_LeaderId",
                table: "Cells",
                column: "LeaderId",
                principalTable: "PersonalInfos",
                principalColumn: "Document",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassAttendancePersonalInfo_PersonalInfos_AttendeesDocument",
                table: "ClassAttendancePersonalInfo",
                column: "AttendeesDocument",
                principalTable: "PersonalInfos",
                principalColumn: "Document",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassStudents_PersonalInfos_StudentId",
                table: "ClassStudents",
                column: "StudentId",
                principalTable: "PersonalInfos",
                principalColumn: "Document",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConventionAttendees_PersonalInfos_AttendeeId",
                table: "ConventionAttendees",
                column: "AttendeeId",
                principalTable: "PersonalInfos",
                principalColumn: "Document",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConventionAttendees_PersonalInfos_InvitedById",
                table: "ConventionAttendees",
                column: "InvitedById",
                principalTable: "PersonalInfos",
                principalColumn: "Document");

            migrationBuilder.AddForeignKey(
                name: "FK_Gaineds_PersonalInfos_InvitedById",
                table: "Gaineds",
                column: "InvitedById",
                principalTable: "PersonalInfos",
                principalColumn: "Document");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalInfos_Cells_CellId",
                table: "PersonalInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_Gaineds_PersonalInfos_InvitedById",
                table: "Gaineds");

            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "CellAttendancePersonalInfo");

            migrationBuilder.DropTable(
                name: "ClassAttendancePersonalInfo");

            migrationBuilder.DropTable(
                name: "ClassStudents");

            migrationBuilder.DropTable(
                name: "ConventionAttendees");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "MeetingAttendances");

            migrationBuilder.DropTable(
                name: "MinistryManagements");

            migrationBuilder.DropTable(
                name: "CellAttendance");

            migrationBuilder.DropTable(
                name: "ClassAttendances");

            migrationBuilder.DropTable(
                name: "Conventions");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Ministries");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Cells");

            migrationBuilder.DropTable(
                name: "PersonalInfos");

            migrationBuilder.DropTable(
                name: "Gaineds");
        }
    }
}
