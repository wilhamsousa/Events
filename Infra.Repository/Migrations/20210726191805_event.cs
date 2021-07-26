using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Repository.Migrations
{
    public partial class @event : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("41fc88fd-849e-49d1-bd39-e251d872cb90"), "Churrasco de aniversariantes do mês" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");
        }
    }
}
