using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CabinetVeterinar.Migrations
{
    public partial class VetForPets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShowVetAnimalsModelId",
                table: "Animal",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShowVetAnimalsModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowVetAnimalsModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShowVetAnimalsModel_Vet_VetId",
                        column: x => x.VetId,
                        principalTable: "Vet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_ShowVetAnimalsModelId",
                table: "Animal",
                column: "ShowVetAnimalsModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowVetAnimalsModel_VetId",
                table: "ShowVetAnimalsModel",
                column: "VetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_ShowVetAnimalsModel_ShowVetAnimalsModelId",
                table: "Animal",
                column: "ShowVetAnimalsModelId",
                principalTable: "ShowVetAnimalsModel",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_ShowVetAnimalsModel_ShowVetAnimalsModelId",
                table: "Animal");

            migrationBuilder.DropTable(
                name: "ShowVetAnimalsModel");

            migrationBuilder.DropIndex(
                name: "IX_Animal_ShowVetAnimalsModelId",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "ShowVetAnimalsModelId",
                table: "Animal");
        }
    }
}
