using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace api.Migrations
{
    public partial class Fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "baggage_pkey",
                table: "baggage");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "rute",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "flight",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "uniqueid",
                table: "baggage",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "rute",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "flight",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "baggage",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_baggage",
                table: "baggage",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_rute_Id",
                table: "rute",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_flight_Id",
                table: "flight",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_baggage_Id",
                table: "baggage",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_rute_Id",
                table: "rute");

            migrationBuilder.DropIndex(
                name: "IX_flight_Id",
                table: "flight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_baggage",
                table: "baggage");

            migrationBuilder.DropIndex(
                name: "IX_baggage_Id",
                table: "baggage");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "rute",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "flight",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "baggage",
                newName: "uniqueid");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "rute",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "flight",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "uniqueid",
                table: "baggage",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "baggage_pkey",
                table: "baggage",
                column: "uniqueid");
        }
    }
}
