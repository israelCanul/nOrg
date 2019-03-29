using Microsoft.EntityFrameworkCore.Migrations;

namespace narilearsi.Migrations
{
    public partial class UpdatePersons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Persons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Persons");
        }
    }
}
