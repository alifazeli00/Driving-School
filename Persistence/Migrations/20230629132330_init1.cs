using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListDatesTeory_DatesTeory_DatesTeoryId",
                table: "ListDatesTeory");

            migrationBuilder.AlterColumn<int>(
                name: "DatesTeoryId",
                table: "ListDatesTeory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ListDatesTeory_DatesTeory_DatesTeoryId",
                table: "ListDatesTeory",
                column: "DatesTeoryId",
                principalTable: "DatesTeory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListDatesTeory_DatesTeory_DatesTeoryId",
                table: "ListDatesTeory");

            migrationBuilder.AlterColumn<int>(
                name: "DatesTeoryId",
                table: "ListDatesTeory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ListDatesTeory_DatesTeory_DatesTeoryId",
                table: "ListDatesTeory",
                column: "DatesTeoryId",
                principalTable: "DatesTeory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
