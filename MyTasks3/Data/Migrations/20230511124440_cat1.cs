using Microsoft.EntityFrameworkCore.Migrations;

namespace MyTasks3.Data.Migrations
{
    public partial class cat1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMainCategory",
                table: "Categories",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMainCategory",
                table: "Categories");
        }
    }
}
