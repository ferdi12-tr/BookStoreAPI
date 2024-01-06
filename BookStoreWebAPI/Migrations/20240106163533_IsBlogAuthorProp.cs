using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreWebAPI.Migrations
{
    public partial class IsBlogAuthorProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsBlogAuthor",
                table: "Author",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBlogAuthor",
                table: "Author");
        }
    }
}
