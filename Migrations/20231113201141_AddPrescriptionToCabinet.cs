using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CabinetVeterinar.Migrations
{
    public partial class AddPrescriptionToCabinet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Prescription",
                table: "Cabinet",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prescription",
                table: "Cabinet");
        }
    }
}
