using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class MetaFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Caregory",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Post",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Caregory",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Post");
        }
    }
}
