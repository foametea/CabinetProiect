using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CabinetVeterinar.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_Cabinet_CabinetId",
                table: "Animal");

            migrationBuilder.DropIndex(
                name: "IX_Animal_CabinetId",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "CabinetId",
                table: "Animal");

            migrationBuilder.AddColumn<int>(
                name: "AnimalID",
                table: "Cabinet",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cabinet_AnimalID",
                table: "Cabinet",
                column: "AnimalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cabinet_Animal_AnimalID",
                table: "Cabinet",
                column: "AnimalID",
                principalTable: "Animal",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabinet_Animal_AnimalID",
                table: "Cabinet");

            migrationBuilder.DropIndex(
                name: "IX_Cabinet_AnimalID",
                table: "Cabinet");

            migrationBuilder.DropColumn(
                name: "AnimalID",
                table: "Cabinet");

            migrationBuilder.AddColumn<int>(
                name: "CabinetId",
                table: "Animal",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animal_CabinetId",
                table: "Animal",
                column: "CabinetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_Cabinet_CabinetId",
                table: "Animal",
                column: "CabinetId",
                principalTable: "Cabinet",
                principalColumn: "CabinetId");
        }
    }
}
