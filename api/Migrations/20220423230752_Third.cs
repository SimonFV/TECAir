using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "order",
                table: "scale",
                newName: "order_landing");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "order_landing",
                table: "scale",
                newName: "order");
        }
    }
}
