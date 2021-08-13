using Microsoft.EntityFrameworkCore.Migrations;

namespace EquipmentRental.DAL.Migrations
{
    public partial class AddUsefulLife : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsefulLife",
                table: "Equipments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsefulLife",
                table: "Equipments");
        }
    }
}
