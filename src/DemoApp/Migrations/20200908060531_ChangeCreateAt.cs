using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoApp.Migrations
{
    public partial class ChangeCreateAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedTimestamp",
                table: "Blogs",
                newName: "CreateAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "Blogs",
                newName: "CreatedTimestamp");
        }
    }
}
