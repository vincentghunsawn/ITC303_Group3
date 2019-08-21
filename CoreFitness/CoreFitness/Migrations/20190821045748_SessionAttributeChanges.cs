using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreFitness.Migrations
{
    public partial class SessionAttributeChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SessionTime",
                table: "Timetable",
                newName: "SessionStartTime");

            migrationBuilder.AddColumn<int>(
                name: "Day",
                table: "Timetable",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SessionEndTime",
                table: "Timetable",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "Timetable");

            migrationBuilder.DropColumn(
                name: "SessionEndTime",
                table: "Timetable");

            migrationBuilder.RenameColumn(
                name: "SessionStartTime",
                table: "Timetable",
                newName: "SessionTime");
        }
    }
}
