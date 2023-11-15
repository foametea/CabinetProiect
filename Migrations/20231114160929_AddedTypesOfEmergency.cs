using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CabinetVeterinar.Migrations
{
    public partial class AddedTypesOfEmergency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmergencyType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfUrgency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyType", x => x.ID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CabinetEmergencyType");

            migrationBuilder.DropTable(
                name: "EmergencyType");
        }
    }
}
