using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NF_Portal.Migrations
{
    public partial class editableFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Editable",
                table: "NfPrograms",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Editable",
                table: "NfPrograms");
        }
    }
}
