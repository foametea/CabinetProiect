using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CabinetVeterinar.Migrations
{
    public partial class modificare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CabinetEmergencyType");

            migrationBuilder.AddColumn<int>(
                name: "CabinetId",
                table: "EmergencyType",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CabinetTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabinetID = table.Column<int>(type: "int", nullable: false),
                    EmergencyTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinetTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CabinetTypes_Cabinet_CabinetID",
                        column: x => x.CabinetID,
                        principalTable: "Cabinet",
                        principalColumn: "CabinetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CabinetTypes_EmergencyType_EmergencyTypeId",
                        column: x => x.EmergencyTypeId,
                        principalTable: "EmergencyType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyType_CabinetId",
                table: "EmergencyType",
                column: "CabinetId");

            migrationBuilder.CreateIndex(
                name: "IX_CabinetTypes_CabinetID",
                table: "CabinetTypes",
                column: "CabinetID");

            migrationBuilder.CreateIndex(
                name: "IX_CabinetTypes_EmergencyTypeId",
                table: "CabinetTypes",
                column: "EmergencyTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyType_Cabinet_CabinetId",
                table: "EmergencyType",
                column: "CabinetId",
                principalTable: "Cabinet",
                principalColumn: "CabinetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyType_Cabinet_CabinetId",
                table: "EmergencyType");

            migrationBuilder.DropTable(
                name: "CabinetTypes");

            migrationBuilder.DropIndex(
                name: "IX_EmergencyType_CabinetId",
                table: "EmergencyType");

            migrationBuilder.DropColumn(
                name: "CabinetId",
                table: "EmergencyType");

            migrationBuilder.CreateTable(
                name: "CabinetEmergencyType",
                columns: table => new
                {
                    CabinetsCabinetId = table.Column<int>(type: "int", nullable: false),
                    EmergencyTypesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinetEmergencyType", x => new { x.CabinetsCabinetId, x.EmergencyTypesID });
                    table.ForeignKey(
                        name: "FK_CabinetEmergencyType_Cabinet_CabinetsCabinetId",
                        column: x => x.CabinetsCabinetId,
                        principalTable: "Cabinet",
                        principalColumn: "CabinetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CabinetEmergencyType_EmergencyType_EmergencyTypesID",
                        column: x => x.EmergencyTypesID,
                        principalTable: "EmergencyType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CabinetEmergencyType_EmergencyTypesID",
                table: "CabinetEmergencyType",
                column: "EmergencyTypesID");
        }
    }
}
