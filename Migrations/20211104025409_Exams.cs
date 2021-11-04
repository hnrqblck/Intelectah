using Microsoft.EntityFrameworkCore.Migrations;

namespace intelectah.Migrations
{
    public partial class Exams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamName = table.Column<string>(maxLength: 100, nullable: false),
                    ExamDescription = table.Column<string>(maxLength: 1000, nullable: true),
                    ExamsTypesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_ExamsTypes_ExamsTypesId",
                        column: x => x.ExamsTypesId,
                        principalTable: "ExamsTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exams_ExamsTypesId",
                table: "Exams",
                column: "ExamsTypesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exams");
        }
    }
}
