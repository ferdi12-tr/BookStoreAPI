using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreWebAPI.Migrations
{
    public partial class deleteProductIdProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Author");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Author",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
