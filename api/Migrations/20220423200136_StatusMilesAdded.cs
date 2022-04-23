using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class StatusMilesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "miles",
                table: "rute",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "book",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "baggage",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "miles",
                table: "rute");

            migrationBuilder.DropColumn(
                name: "status",
                table: "book");

            migrationBuilder.DropColumn(
                name: "status",
                table: "baggage");
        }
    }
}
