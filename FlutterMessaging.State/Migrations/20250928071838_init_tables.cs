using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlutterMessaging.State.Migrations
{
    /// <inheritdoc />
    public partial class init_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:pgcrypto", ",,");

            migrationBuilder.CreateTable(
                name: "chat_rooms",
                columns: table => new
                {
                    chat_room_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_chat_rooms", x => x.chat_room_id);
                });

            migrationBuilder.CreateTable(
                name: "flash_card_set_templates",
                columns: table => new
                {
                    flash_card_set_template_id = table.Column<Guid>(type: "uuid", nullable: false),
                    flash_card_set_name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_flash_card_set_templates", x => x.flash_card_set_template_id);
                });

            migrationBuilder.CreateTable(
                name: "language_translations",
                columns: table => new
                {
                    language_translation_id = table.Column<Guid>(type: "uuid", nullable: false),
                    from_language_id = table.Column<Guid>(type: "uuid", nullable: false),
                    to_language_id = table.Column<Guid>(type: "uuid", nullable: false),
                    from_language_text = table.Column<string>(type: "text", nullable: false),
                    to_language_text = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_language_translations", x => x.language_translation_id);
                });

            migrationBuilder.CreateTable(
                name: "profiles",
                columns: table => new
                {
                    profile_id = table.Column<Guid>(type: "uuid", nullable: false),
                    profile_name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_profiles", x => x.profile_id);
                });

            migrationBuilder.CreateTable(
                name: "flash_card_set_template_items",
                columns: table => new
                {
                    flash_card_set_template_item_id = table.Column<Guid>(type: "uuid", nullable: false),
                    flash_card_set_template_id = table.Column<Guid>(type: "uuid", nullable: false),
                    question = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_flash_card_set_template_items", x => x.flash_card_set_template_item_id);
                    table.ForeignKey(
                        name: "fk_flash_card_set_template_items_flash_card_set_templates_flas",
                        column: x => x.flash_card_set_template_id,
                        principalTable: "flash_card_set_templates",
                        principalColumn: "flash_card_set_template_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "language_word_frequencies",
                columns: table => new
                {
                    language_word_frequency_id = table.Column<Guid>(type: "uuid", nullable: false),
                    language_id = table.Column<Guid>(type: "uuid", nullable: false),
                    language_translation_id = table.Column<Guid>(type: "uuid", nullable: false),
                    frequency_rank = table.Column<int>(type: "integer", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_language_word_frequencies", x => x.language_word_frequency_id);
                    table.ForeignKey(
                        name: "fk_language_word_frequencies_language_translations_language_tr",
                        column: x => x.language_translation_id,
                        principalTable: "language_translations",
                        principalColumn: "language_translation_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chat_room_members",
                columns: table => new
                {
                    chat_room_member_id = table.Column<Guid>(type: "uuid", nullable: false),
                    chat_room_id = table.Column<Guid>(type: "uuid", nullable: false),
                    profile_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_chat_room_members", x => x.chat_room_member_id);
                    table.ForeignKey(
                        name: "fk_chat_room_members_chat_rooms_chat_room_id",
                        column: x => x.chat_room_id,
                        principalTable: "chat_rooms",
                        principalColumn: "chat_room_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_chat_room_members_profile_profile_id",
                        column: x => x.profile_id,
                        principalTable: "profiles",
                        principalColumn: "profile_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "chat_room_messages",
                columns: table => new
                {
                    chat_room_message_id = table.Column<Guid>(type: "uuid", nullable: false),
                    profile_id = table.Column<Guid>(type: "uuid", nullable: false),
                    chat_room_id = table.Column<Guid>(type: "uuid", nullable: false),
                    message_text = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_chat_room_messages", x => x.chat_room_message_id);
                    table.ForeignKey(
                        name: "fk_chat_room_messages_chat_rooms_chat_room_id",
                        column: x => x.chat_room_id,
                        principalTable: "chat_rooms",
                        principalColumn: "chat_room_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_chat_room_messages_profile_profile_id",
                        column: x => x.profile_id,
                        principalTable: "profiles",
                        principalColumn: "profile_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "profile_settings",
                columns: table => new
                {
                    profile_setting_id = table.Column<Guid>(type: "uuid", nullable: false),
                    profile_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_profile_settings", x => x.profile_setting_id);
                    table.ForeignKey(
                        name: "fk_profile_settings_profiles_profile_id",
                        column: x => x.profile_id,
                        principalTable: "profiles",
                        principalColumn: "profile_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "flash_card_answers",
                columns: table => new
                {
                    flash_card_answer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    flash_card_set_template_item_id = table.Column<Guid>(type: "uuid", nullable: false),
                    profile_id = table.Column<Guid>(type: "uuid", nullable: false),
                    answer = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_flash_card_answers", x => x.flash_card_answer_id);
                    table.ForeignKey(
                        name: "fk_flash_card_answers_flash_card_set_template_item_flash_card_",
                        column: x => x.flash_card_set_template_item_id,
                        principalTable: "flash_card_set_template_items",
                        principalColumn: "flash_card_set_template_item_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_flash_card_answers_profile_profile_id",
                        column: x => x.profile_id,
                        principalTable: "profiles",
                        principalColumn: "profile_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "profile_setting_options",
                columns: table => new
                {
                    profile_setting_option_id = table.Column<Guid>(type: "uuid", nullable: false),
                    profile_setting_id = table.Column<Guid>(type: "uuid", nullable: false),
                    option_key = table.Column<string>(type: "text", nullable: false),
                    option_value = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    modified_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_profile_setting_options", x => x.profile_setting_option_id);
                    table.ForeignKey(
                        name: "fk_profile_setting_options_profile_settings_profile_setting_id",
                        column: x => x.profile_setting_id,
                        principalTable: "profile_settings",
                        principalColumn: "profile_setting_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_chat_room_members_chat_room_id",
                table: "chat_room_members",
                column: "chat_room_id");

            migrationBuilder.CreateIndex(
                name: "ix_chat_room_members_profile_id",
                table: "chat_room_members",
                column: "profile_id");

            migrationBuilder.CreateIndex(
                name: "ix_chat_room_messages_chat_room_id",
                table: "chat_room_messages",
                column: "chat_room_id");

            migrationBuilder.CreateIndex(
                name: "ix_chat_room_messages_profile_id",
                table: "chat_room_messages",
                column: "profile_id");

            migrationBuilder.CreateIndex(
                name: "ix_flash_card_answers_flash_card_set_template_item_id",
                table: "flash_card_answers",
                column: "flash_card_set_template_item_id");

            migrationBuilder.CreateIndex(
                name: "ix_flash_card_answers_profile_id",
                table: "flash_card_answers",
                column: "profile_id");

            migrationBuilder.CreateIndex(
                name: "ix_flash_card_set_template_items_flash_card_set_template_id",
                table: "flash_card_set_template_items",
                column: "flash_card_set_template_id");

            migrationBuilder.CreateIndex(
                name: "ix_language_word_frequencies_language_translation_id",
                table: "language_word_frequencies",
                column: "language_translation_id");

            migrationBuilder.CreateIndex(
                name: "ix_profile_setting_options_profile_setting_id",
                table: "profile_setting_options",
                column: "profile_setting_id");

            migrationBuilder.CreateIndex(
                name: "ix_profile_settings_profile_id",
                table: "profile_settings",
                column: "profile_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chat_room_members");

            migrationBuilder.DropTable(
                name: "chat_room_messages");

            migrationBuilder.DropTable(
                name: "flash_card_answers");

            migrationBuilder.DropTable(
                name: "language_word_frequencies");

            migrationBuilder.DropTable(
                name: "profile_setting_options");

            migrationBuilder.DropTable(
                name: "chat_rooms");

            migrationBuilder.DropTable(
                name: "flash_card_set_template_items");

            migrationBuilder.DropTable(
                name: "language_translations");

            migrationBuilder.DropTable(
                name: "profile_settings");

            migrationBuilder.DropTable(
                name: "flash_card_set_templates");

            migrationBuilder.DropTable(
                name: "profiles");
        }
    }
}
