using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Repository.Migrations
{
    public partial class guest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observation",
                table: "Event",
                type: "varchar(200)",
                unicode: false,
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceWithDrink",
                table: "Event",
                type: "decimal(9,2)",
                precision: 9,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceWithoutDrink",
                table: "Event",
                type: "decimal(9,2)",
                precision: 9,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Payment = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Guest_Event",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Event",
                keyColumn: "Id",
                keyValue: new Guid("41fc88fd-849e-49d1-bd39-e251d872cb90"),
                columns: new[] { "PriceWithDrink", "PriceWithoutDrink" },
                values: new object[] { 100m, 50m });

            migrationBuilder.InsertData(
                table: "Guest",
                columns: new[] { "Id", "EventId", "Name", "Payment" },
                values: new object[] { new Guid("7df2d51f-7f53-4f84-865a-bd27a3f9323d"), new Guid("41fc88fd-849e-49d1-bd39-e251d872cb90"), "Participante teste", null });

            migrationBuilder.CreateIndex(
                name: "IX_Guest_EventId",
                table: "Guest",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropColumn(
                name: "Observation",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "PriceWithDrink",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "PriceWithoutDrink",
                table: "Event");
        }
    }
}
