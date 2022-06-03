using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appointment.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TimeSlot",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Start = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    End = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSlot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkingScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BreakId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_TimeSlot_BreakId",
                        column: x => x.BreakId,
                        principalTable: "TimeSlot",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_TimeSlot_WorkingScheduleId",
                        column: x => x.WorkingScheduleId,
                        principalTable: "TimeSlot",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "TimeSlot",
                columns: new[] { "Id", "End", "Name", "Start" },
                values: new object[] { new Guid("7a44de32-c577-40e8-b638-8059d4d821d4"), "06:00:00 PM", "Working Schedule", "09:00:00 AM" });

            migrationBuilder.InsertData(
                table: "TimeSlot",
                columns: new[] { "Id", "End", "Name", "Start" },
                values: new object[] { new Guid("7a44de32-c577-40e8-b638-8059d4d821d5"), "01:00:00 PM", "Break Schedule", "12:00:00 PM" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "BreakId", "Email", "Name", "WorkingScheduleId" },
                values: new object[] { new Guid("ec450a2d-1675-4199-b742-fee1becbbdfb"), new Guid("7a44de32-c577-40e8-b638-8059d4d821d5"), "abdullahrexha09@gmail.com", "Abdullah", new Guid("7a44de32-c577-40e8-b638-8059d4d821d4") });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_BreakId",
                table: "Employee",
                column: "BreakId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_WorkingScheduleId",
                table: "Employee",
                column: "WorkingScheduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "TimeSlot");
        }
    }
}
