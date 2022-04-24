using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class Seventh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ssn",
                table: "book",
                newName: "id_user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id_user",
                table: "book",
                newName: "ssn");
        }
    }
}
