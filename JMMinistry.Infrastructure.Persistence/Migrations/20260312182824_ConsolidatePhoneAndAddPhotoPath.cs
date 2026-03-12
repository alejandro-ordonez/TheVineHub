using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JMMinistry.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ConsolidatePhoneAndAddPhotoPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Copy Phone values to PhoneNumber (IdentityUser column) where PhoneNumber is null
            migrationBuilder.Sql("""
                UPDATE "PersonalInfo" SET "PhoneNumber" = "Phone" WHERE "PhoneNumber" IS NULL AND "Phone" IS NOT NULL
                """);

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "PersonalInfo");

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "PersonalInfo",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "PersonalInfo");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "PersonalInfo",
                type: "text",
                nullable: true);

            // Copy PhoneNumber back to Phone
            migrationBuilder.Sql("""
                UPDATE "PersonalInfo" SET "Phone" = "PhoneNumber"
                """);
        }
    }
}
