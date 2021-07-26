using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Repository.Migrations
{
    public partial class eventdescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Event",
                newName: "Description");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Event",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Event",
                newName: "Name");
        }
    }
}
