using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace narilearsi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    EventTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    etName = table.Column<string>(nullable: true),
                    etDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.EventTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    eventName = table.Column<string>(nullable: true),
                    eventDescription = table.Column<string>(nullable: true),
                    eventDate = table.Column<DateTime>(nullable: false),
                    eventStatus = table.Column<string>(nullable: true),
                    EventoEventTypeIdEventTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Event_EventType_EventoEventTypeIdEventTypeId",
                        column: x => x.EventoEventTypeIdEventTypeId,
                        principalTable: "EventType",
                        principalColumn: "EventTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhotoPackage",
                columns: table => new
                {
                    photoPackageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ppName = table.Column<string>(nullable: true),
                    ppDescription = table.Column<string>(nullable: true),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoPackage", x => x.photoPackageId);
                    table.ForeignKey(
                        name: "FK_PhotoPackage_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemPackage",
                columns: table => new
                {
                    itemPackageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    itemTypeId = table.Column<int>(nullable: false),
                    itemName = table.Column<string>(nullable: true),
                    itemDescription = table.Column<string>(nullable: true),
                    itemSize = table.Column<string>(nullable: true),
                    itemNotes = table.Column<string>(nullable: true),
                    packageId = table.Column<int>(nullable: false),
                    photoPackageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPackage", x => x.itemPackageId);
                    table.ForeignKey(
                        name: "FK_ItemPackage_PhotoPackage_photoPackageId",
                        column: x => x.photoPackageId,
                        principalTable: "PhotoPackage",
                        principalColumn: "photoPackageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    itemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    source = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    itemPackageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.itemId);
                    table.ForeignKey(
                        name: "FK_Item_ItemPackage_itemPackageId",
                        column: x => x.itemPackageId,
                        principalTable: "ItemPackage",
                        principalColumn: "itemPackageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventoEventTypeIdEventTypeId",
                table: "Event",
                column: "EventoEventTypeIdEventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_itemPackageId",
                table: "Item",
                column: "itemPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPackage_photoPackageId",
                table: "ItemPackage",
                column: "photoPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoPackage_EventId",
                table: "PhotoPackage",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "ItemPackage");

            migrationBuilder.DropTable(
                name: "PhotoPackage");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "EventType");
        }
    }
}
