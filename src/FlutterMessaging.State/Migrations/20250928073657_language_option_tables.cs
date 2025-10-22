using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlutterMessaging.State.Migrations
{
    /// <inheritdoc />
    public partial class language_option_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_language_word_frequencies_language_translations_language_tr",
                table: "language_word_frequencies");

            migrationBuilder.DropIndex(
                name: "ix_language_word_frequencies_language_translation_id",
                table: "language_word_frequencies");

            migrationBuilder.AddColumn<Guid>(
                name: "langauge_language_id",
                table: "language_translations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "flash_card_set_template_item_options",
                columns: table => new
                {
                    flash_card_set_template_item_option_id = table.Column<Guid>(type: "uuid", nullable: false),
                    flash_card_set_template_item_id = table.Column<Guid>(type: "uuid", nullable: false),
                    option_key = table.Column<string>(type: "text", nullable: false),
                    option_value = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_flash_card_set_template_item_options", x => x.flash_card_set_template_item_option_id);
                    table.ForeignKey(
                        name: "fk_flash_card_set_template_item_options_flash_card_set_templat",
                        column: x => x.flash_card_set_template_item_id,
                        principalTable: "flash_card_set_template_items",
                        principalColumn: "flash_card_set_template_item_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    language_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_languages", x => x.language_id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_language_word_frequencies_language_id",
                table: "language_word_frequencies",
                column: "language_id");

            migrationBuilder.CreateIndex(
                name: "ix_language_translations_langauge_language_id",
                table: "language_translations",
                column: "langauge_language_id");

            migrationBuilder.CreateIndex(
                name: "ix_flash_card_set_template_item_options_flash_card_set_templat",
                table: "flash_card_set_template_item_options",
                column: "flash_card_set_template_item_id");

            migrationBuilder.AddForeignKey(
                name: "fk_language_translations_languages_langauge_language_id",
                table: "language_translations",
                column: "langauge_language_id",
                principalTable: "Languages",
                principalColumn: "language_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_language_word_frequencies_languages_language_id",
                table: "language_word_frequencies",
                column: "language_id",
                principalTable: "Languages",
                principalColumn: "language_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_language_translations_languages_langauge_language_id",
                table: "language_translations");

            migrationBuilder.DropForeignKey(
                name: "fk_language_word_frequencies_languages_language_id",
                table: "language_word_frequencies");

            migrationBuilder.DropTable(
                name: "flash_card_set_template_item_options");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropIndex(
                name: "ix_language_word_frequencies_language_id",
                table: "language_word_frequencies");

            migrationBuilder.DropIndex(
                name: "ix_language_translations_langauge_language_id",
                table: "language_translations");

            migrationBuilder.DropColumn(
                name: "langauge_language_id",
                table: "language_translations");

            migrationBuilder.CreateIndex(
                name: "ix_language_word_frequencies_language_translation_id",
                table: "language_word_frequencies",
                column: "language_translation_id");

            migrationBuilder.AddForeignKey(
                name: "fk_language_word_frequencies_language_translations_language_tr",
                table: "language_word_frequencies",
                column: "language_translation_id",
                principalTable: "language_translations",
                principalColumn: "language_translation_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
