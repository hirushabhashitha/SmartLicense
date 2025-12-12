using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartLicenseAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToLicenseApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "LicenseApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LicenseApplications");
        }
    }
}
