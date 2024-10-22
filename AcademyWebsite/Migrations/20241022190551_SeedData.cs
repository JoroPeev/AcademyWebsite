using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademyWebsite.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RegistrationData",
                columns: new[] { "Id", "ChildAge", "ChildName", "EmailAddress", "ParentName", "PhoneNumber" },
                values: new object[] { 1, 5, "Penka", "JonDoe@gmail.com", "Stanka", "1234567890" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RegistrationData",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
