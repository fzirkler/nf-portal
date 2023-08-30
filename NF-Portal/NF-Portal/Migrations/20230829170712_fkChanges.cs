using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NF_Portal.Migrations
{
    public partial class fkChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NfEvent_NfPrograms_NfProgramId",
                table: "NfEvent");

            migrationBuilder.DropColumn(
                name: "ProgramId",
                table: "NfEvent");

            migrationBuilder.AlterColumn<int>(
                name: "NfProgramId",
                table: "NfEvent",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_NfEvent_NfPrograms_NfProgramId",
                table: "NfEvent",
                column: "NfProgramId",
                principalTable: "NfPrograms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NfEvent_NfPrograms_NfProgramId",
                table: "NfEvent");

            migrationBuilder.AlterColumn<int>(
                name: "NfProgramId",
                table: "NfEvent",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProgramId",
                table: "NfEvent",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_NfEvent_NfPrograms_NfProgramId",
                table: "NfEvent",
                column: "NfProgramId",
                principalTable: "NfPrograms",
                principalColumn: "Id");
        }
    }
}
