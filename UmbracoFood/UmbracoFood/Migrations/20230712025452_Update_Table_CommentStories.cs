using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UmbracoFood.Migrations
{
    /// <inheritdoc />
    public partial class Update_Table_CommentStories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CmtId",
                table: "CommentStories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CmtId",
                table: "CommentStories");
        }
    }
}
