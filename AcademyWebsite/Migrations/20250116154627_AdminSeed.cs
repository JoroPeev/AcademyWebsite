using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademyWebsite.Migrations
{
    /// <inheritdoc />
    public partial class AdminSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrationData");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistrationData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildAge = table.Column<int>(type: "int", nullable: false),
                    ChildName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrationData", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RegistrationData",
                columns: new[] { "Id", "ChildAge", "ChildName", "EmailAddress", "ParentName", "PhoneNumber" },
                values: new object[] { 1, 5, "Penka", "JonDoe@gmail.com", "Stanka", "1234567890" });
        }
    }
}
