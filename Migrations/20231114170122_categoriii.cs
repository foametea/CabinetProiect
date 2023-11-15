using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CabinetVeterinar.Migrations
{
    public partial class categoriii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyType_Cabinet_CabinetId",
                table: "EmergencyType");

            migrationBuilder.DropIndex(
                name: "IX_EmergencyType_CabinetId",
                table: "EmergencyType");

            migrationBuilder.DropColumn(
                name: "CabinetId",
                table: "EmergencyType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CabinetId",
                table: "EmergencyType",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyType_CabinetId",
                table: "EmergencyType",
                column: "CabinetId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyType_Cabinet_CabinetId",
                table: "EmergencyType",
                column: "CabinetId",
                principalTable: "Cabinet",
                principalColumn: "CabinetId");
        }
    }
}
