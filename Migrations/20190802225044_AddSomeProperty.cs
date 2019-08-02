using Microsoft.EntityFrameworkCore.Migrations;

namespace WeCode.Migrations
{
    public partial class AddSomeProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SomeProperty",
                table: "Talents",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SomeProperty",
                table: "Talents");
        }
    }
}
