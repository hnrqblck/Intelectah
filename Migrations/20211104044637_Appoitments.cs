using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace intelectah.Migrations
{
    public partial class Appoitments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(nullable: false),
                    ExamsTypesId = table.Column<int>(nullable: true),
                    ExamsId = table.Column<int>(nullable: false),
                    AppointmentTime = table.Column<DateTime>(nullable: false),
                    Protocol = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Exams_ExamsId",
                        column: x => x.ExamsId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_ExamsTypes_ExamsTypesId",
                        column: x => x.ExamsTypesId,
                        principalTable: "ExamsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ExamsId",
                table: "Appointments",
                column: "ExamsId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ExamsTypesId",
                table: "Appointments",
                column: "ExamsTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");
        }
    }
}
