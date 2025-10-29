using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlutterMessaging.State.Migrations
{
    /// <inheritdoc />
    public partial class addTemplateType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "flash_card_type",
                table: "flash_card_set_templates",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "flash_card_type",
                table: "flash_card_set_templates");
        }
    }
}
