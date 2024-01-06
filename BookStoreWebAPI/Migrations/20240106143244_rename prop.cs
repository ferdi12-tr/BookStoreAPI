using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreWebAPI.Migrations
{
    public partial class renameprop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Comment",
                newName: "BlogComment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlogComment",
                table: "Comment",
                newName: "Content");
        }
    }
}
