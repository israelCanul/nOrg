using Microsoft.EntityFrameworkCore.Migrations;

namespace narilearsi.Migrations
{
    public partial class AddRelationEventToPersons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonsPersonID",
                table: "Event",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Event_PersonsPersonID",
                table: "Event",
                column: "PersonsPersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Persons_PersonsPersonID",
                table: "Event",
                column: "PersonsPersonID",
                principalTable: "Persons",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Persons_PersonsPersonID",
                table: "Event");

            migrationBuilder.DropIndex(
                name: "IX_Event_PersonsPersonID",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "PersonsPersonID",
                table: "Event");
        }
    }
}
