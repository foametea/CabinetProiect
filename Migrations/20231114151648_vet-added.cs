using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CabinetVeterinar.Migrations
{
    public partial class vetadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VetID",
                table: "Cabinet",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceYears = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vet", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cabinet_VetID",
                table: "Cabinet",
                column: "VetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cabinet_Vet_VetID",
                table: "Cabinet",
                column: "VetID",
                principalTable: "Vet",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabinet_Vet_VetID",
                table: "Cabinet");

            migrationBuilder.DropTable(
                name: "Vet");

            migrationBuilder.DropIndex(
                name: "IX_Cabinet_VetID",
                table: "Cabinet");

            migrationBuilder.DropColumn(
                name: "VetID",
                table: "Cabinet");
        }
    }
}
