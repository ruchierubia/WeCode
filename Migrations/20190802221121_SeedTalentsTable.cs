using Microsoft.EntityFrameworkCore.Migrations;

namespace WeCode.Migrations
{
    public partial class SeedTalentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Talents",
                columns: new[] { "Id", "Email", "Name", "Skills" },
                values: new object[] { 1, "KingJames@gmail.com", "Lebron James", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Talents",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
