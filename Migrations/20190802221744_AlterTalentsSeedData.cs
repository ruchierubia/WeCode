using Microsoft.EntityFrameworkCore.Migrations;

namespace WeCode.Migrations
{
    public partial class AlterTalentsSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Talents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Skills",
                value: 4);

            migrationBuilder.InsertData(
                table: "Talents",
                columns: new[] { "Id", "Email", "Name", "Skills" },
                values: new object[] { 2, "theBrow@gmail.com", "Anthony Davis", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Talents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Talents",
                keyColumn: "Id",
                keyValue: 1,
                column: "Skills",
                value: 1);
        }
    }
}
