CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    migration_id character varying(150) NOT NULL,
    product_version character varying(32) NOT NULL,
    CONSTRAINT pk___ef_migrations_history PRIMARY KEY (migration_id)
);

START TRANSACTION;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251029033850_messagingendpoints') THEN
    CREATE EXTENSION IF NOT EXISTS pgcrypto;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251029033850_messagingendpoints') THEN
    INSERT INTO "__EFMigrationsHistory" (migration_id, product_version)
    VALUES ('20251029033850_messagingendpoints', '9.0.9');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE TABLE chat_rooms (
        chat_room_id uuid NOT NULL,
        name text NOT NULL,
        is_deleted boolean NOT NULL,
        created_at timestamp with time zone NOT NULL DEFAULT (now()),
        modified_at timestamp with time zone NOT NULL DEFAULT (now()),
        CONSTRAINT pk_chat_rooms PRIMARY KEY (chat_room_id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE TABLE flash_card_set_templates (
        flash_card_set_template_id uuid NOT NULL,
        flash_card_set_name text NOT NULL,
        flash_card_type integer NOT NULL,
        is_deleted boolean NOT NULL,
        created_at timestamp with time zone NOT NULL DEFAULT (now()),
        modified_at timestamp with time zone NOT NULL DEFAULT (now()),
        CONSTRAINT pk_flash_card_set_templates PRIMARY KEY (flash_card_set_template_id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE TABLE jwt_keys (
        jwt_key_id uuid NOT NULL,
        kid text NOT NULL,
        alg text NOT NULL,
        public_key_pem text NOT NULL,
        is_active boolean NOT NULL,
        key_vault_key_id text,
        created_at timestamp with time zone NOT NULL DEFAULT (now()),
        modified_at timestamp with time zone NOT NULL DEFAULT (now()),
        is_deleted boolean NOT NULL,
        CONSTRAINT pk_jwt_keys PRIMARY KEY (jwt_key_id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE TABLE "Languages" (
        language_id uuid NOT NULL,
        name text NOT NULL,
        is_deleted boolean NOT NULL,
        created_at timestamp with time zone NOT NULL DEFAULT (now()),
        modified_at timestamp with time zone NOT NULL DEFAULT (now()),
        CONSTRAINT pk_languages PRIMARY KEY (language_id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE TABLE profiles (
        profile_id uuid NOT NULL,
        profile_name text NOT NULL,
        email_address text NOT NULL,
        is_deleted boolean NOT NULL,
        created_at timestamp with time zone NOT NULL DEFAULT (now()),
        modified_at timestamp with time zone NOT NULL DEFAULT (now()),
        CONSTRAINT pk_profiles PRIMARY KEY (profile_id)
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE TABLE flash_card_set_template_items (
        flash_card_set_template_item_id uuid NOT NULL,
        flash_card_set_template_id uuid NOT NULL,
        question text NOT NULL,
        is_deleted boolean NOT NULL,
        created_at timestamp with time zone NOT NULL DEFAULT (now()),
        modified_at timestamp with time zone NOT NULL DEFAULT (now()),
        CONSTRAINT pk_flash_card_set_template_items PRIMARY KEY (flash_card_set_template_item_id),
        CONSTRAINT fk_flash_card_set_template_items_flash_card_set_templates_flas FOREIGN KEY (flash_card_set_template_id) REFERENCES flash_card_set_templates (flash_card_set_template_id) ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE TABLE language_translations (
        language_translation_id uuid NOT NULL,
        from_language_id uuid NOT NULL,
        to_language_id uuid NOT NULL,
        from_language_text text NOT NULL,
        to_language_text text NOT NULL,
        is_deleted boolean NOT NULL,
        created_at timestamp with time zone NOT NULL DEFAULT (now()),
        modified_at timestamp with time zone NOT NULL DEFAULT (now()),
        langauge_language_id uuid NOT NULL,
        CONSTRAINT pk_language_translations PRIMARY KEY (language_translation_id),
        CONSTRAINT fk_language_translations_languages_langauge_language_id FOREIGN KEY (langauge_language_id) REFERENCES "Languages" (language_id) ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE TABLE language_word_frequencies (
        language_word_frequency_id uuid NOT NULL,
        language_id uuid NOT NULL,
        language_translation_id uuid NOT NULL,
        frequency_rank integer NOT NULL,
        is_deleted boolean NOT NULL,
        created_at timestamp with time zone NOT NULL DEFAULT (now()),
        modified_at timestamp with time zone NOT NULL DEFAULT (now()),
        CONSTRAINT pk_language_word_frequencies PRIMARY KEY (language_word_frequency_id),
        CONSTRAINT fk_language_word_frequencies_languages_language_id FOREIGN KEY (language_id) REFERENCES "Languages" (language_id) ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE TABLE chat_room_members (
        chat_room_member_id uuid NOT NULL,
        chat_room_id uuid NOT NULL,
        profile_id uuid NOT NULL,
        last_read_at timestamp with time zone,
        is_deleted boolean NOT NULL,
        created_at timestamp with time zone NOT NULL DEFAULT (now()),
        modified_at timestamp with time zone NOT NULL DEFAULT (now()),
        CONSTRAINT pk_chat_room_members PRIMARY KEY (chat_room_member_id),
        CONSTRAINT fk_chat_room_members_chat_rooms_chat_room_id FOREIGN KEY (chat_room_id) REFERENCES chat_rooms (chat_room_id) ON DELETE CASCADE,
        CONSTRAINT fk_chat_room_members_profile_profile_id FOREIGN KEY (profile_id) REFERENCES profiles (profile_id) ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE TABLE chat_room_messages (
        chat_room_message_id uuid NOT NULL,
        profile_id uuid NOT NULL,
        chat_room_id uuid NOT NULL,
        message_text text NOT NULL,
        is_deleted boolean NOT NULL,
        created_at timestamp with time zone NOT NULL DEFAULT (now()),
        modified_at timestamp with time zone NOT NULL DEFAULT (now()),
        CONSTRAINT pk_chat_room_messages PRIMARY KEY (chat_room_message_id),
        CONSTRAINT fk_chat_room_messages_chat_rooms_chat_room_id FOREIGN KEY (chat_room_id) REFERENCES chat_rooms (chat_room_id) ON DELETE CASCADE,
        CONSTRAINT fk_chat_room_messages_profile_profile_id FOREIGN KEY (profile_id) REFERENCES profiles (profile_id) ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE TABLE external_identities (
        external_identity_id uuid NOT NULL,
        profile_id uuid NOT NULL,
        provider text NOT NULL,
        subject text NOT NULL,
        issuer text NOT NULL,
        is_deleted boolean NOT NULL,
        created_at timestamp with time zone NOT NULL DEFAULT (now()),
        modified_at timestamp with time zone NOT NULL DEFAULT (now()),
        CONSTRAINT pk_external_identities PRIMARY KEY (external_identity_id),
        CONSTRAINT fk_external_identities_profile_profile_id FOREIGN KEY (profile_id) REFERENCES profiles (profile_id) ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE TABLE profile_settings (
        profile_setting_id uuid NOT NULL,
        profile_id uuid NOT NULL,
        is_deleted boolean NOT NULL,
        created_at timestamp with time zone NOT NULL DEFAULT (now()),
        modified_at timestamp with time zone NOT NULL DEFAULT (now()),
        CONSTRAINT pk_profile_settings PRIMARY KEY (profile_setting_id),
        CONSTRAINT fk_profile_settings_profiles_profile_id FOREIGN KEY (profile_id) REFERENCES profiles (profile_id) ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE TABLE sessions (
        session_id uuid NOT NULL,
        profile_id uuid NOT NULL,
        device_info text,
        user_agent text,
        ip_address text,
        revoked_at timestamp with time zone,
        last_seen_at timestamp with time zone,
        device_id text NOT NULL,
        created_at timestamp with time zone NOT NULL DEFAULT (now()),
        modified_at timestamp with time zone NOT NULL DEFAULT (now()),
        is_deleted boolean NOT NULL,
        CONSTRAINT pk_sessions PRIMARY KEY (session_id),
        CONSTRAINT fk_sessions_profiles_profile_id FOREIGN KEY (profile_id) REFERENCES profiles (profile_id) ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE TABLE flash_card_answers (
        flash_card_answer_id uuid NOT NULL,
        flash_card_set_template_item_id uuid NOT NULL,
        profile_id uuid NOT NULL,
        answer text NOT NULL,
        is_deleted boolean NOT NULL,
        created_at timestamp with time zone NOT NULL DEFAULT (now()),
        modified_at timestamp with time zone NOT NULL DEFAULT (now()),
        CONSTRAINT pk_flash_card_answers PRIMARY KEY (flash_card_answer_id),
        CONSTRAINT fk_flash_card_answers_flash_card_set_template_item_flash_card_ FOREIGN KEY (flash_card_set_template_item_id) REFERENCES flash_card_set_template_items (flash_card_set_template_item_id) ON DELETE CASCADE,
        CONSTRAINT fk_flash_card_answers_profile_profile_id FOREIGN KEY (profile_id) REFERENCES profiles (profile_id) ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE TABLE flash_card_set_template_item_options (
        flash_card_set_template_item_option_id uuid NOT NULL,
        flash_card_set_template_item_id uuid NOT NULL,
        option_key text NOT NULL,
        option_value text NOT NULL,
        is_deleted boolean NOT NULL,
        created_at timestamp with time zone NOT NULL DEFAULT (now()),
        modified_at timestamp with time zone NOT NULL DEFAULT (now()),
        CONSTRAINT pk_flash_card_set_template_item_options PRIMARY KEY (flash_card_set_template_item_option_id),
        CONSTRAINT fk_flash_card_set_template_item_options_flash_card_set_templat FOREIGN KEY (flash_card_set_template_item_id) REFERENCES flash_card_set_template_items (flash_card_set_template_item_id) ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE TABLE profile_setting_options (
        profile_setting_option_id uuid NOT NULL,
        profile_setting_id uuid NOT NULL,
        option_key text NOT NULL,
        option_value text NOT NULL,
        is_deleted boolean NOT NULL,
        created_at timestamp with time zone NOT NULL DEFAULT (now()),
        modified_at timestamp with time zone NOT NULL DEFAULT (now()),
        CONSTRAINT pk_profile_setting_options PRIMARY KEY (profile_setting_option_id),
        CONSTRAINT fk_profile_setting_options_profile_settings_profile_setting_id FOREIGN KEY (profile_setting_id) REFERENCES profile_settings (profile_setting_id) ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE TABLE refresh_tokens (
        refresh_token_id uuid NOT NULL,
        session_id uuid NOT NULL,
        token_hash text NOT NULL,
        token_salt text NOT NULL,
        expires_at timestamp with time zone NOT NULL,
        revoked_at timestamp with time zone,
        replaced_by_id uuid,
        created_at timestamp with time zone NOT NULL DEFAULT (now()),
        modified_at timestamp with time zone NOT NULL DEFAULT (now()),
        is_deleted boolean NOT NULL,
        CONSTRAINT pk_refresh_tokens PRIMARY KEY (refresh_token_id),
        CONSTRAINT fk_refresh_tokens_refresh_tokens_replaced_by_id FOREIGN KEY (replaced_by_id) REFERENCES refresh_tokens (refresh_token_id),
        CONSTRAINT fk_refresh_tokens_session_session_id FOREIGN KEY (session_id) REFERENCES sessions (session_id) ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE INDEX ix_chat_room_members_chat_room_id ON chat_room_members (chat_room_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE INDEX ix_chat_room_members_profile_id ON chat_room_members (profile_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE INDEX ix_chat_room_messages_chat_room_id ON chat_room_messages (chat_room_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE INDEX ix_chat_room_messages_profile_id ON chat_room_messages (profile_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE INDEX ix_external_identities_profile_id ON external_identities (profile_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE INDEX ix_flash_card_answers_flash_card_set_template_item_id ON flash_card_answers (flash_card_set_template_item_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE INDEX ix_flash_card_answers_profile_id ON flash_card_answers (profile_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE INDEX ix_flash_card_set_template_item_options_flash_card_set_templat ON flash_card_set_template_item_options (flash_card_set_template_item_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE INDEX ix_flash_card_set_template_items_flash_card_set_template_id ON flash_card_set_template_items (flash_card_set_template_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE INDEX ix_language_translations_langauge_language_id ON language_translations (langauge_language_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE INDEX ix_language_word_frequencies_language_id ON language_word_frequencies (language_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE INDEX ix_profile_setting_options_profile_setting_id ON profile_setting_options (profile_setting_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE INDEX ix_profile_settings_profile_id ON profile_settings (profile_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE INDEX ix_refresh_tokens_replaced_by_id ON refresh_tokens (replaced_by_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE INDEX ix_refresh_tokens_session_id ON refresh_tokens (session_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    CREATE INDEX ix_sessions_profile_id ON sessions (profile_id);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031015035_messagingendpoints2') THEN
    INSERT INTO "__EFMigrationsHistory" (migration_id, product_version)
    VALUES ('20251031015035_messagingendpoints2', '9.0.9');
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "migration_id" = '20251031025124_messaging_fixPrimaryKeyChatRoomMessage') THEN
    INSERT INTO "__EFMigrationsHistory" (migration_id, product_version)
    VALUES ('20251031025124_messaging_fixPrimaryKeyChatRoomMessage', '9.0.9');
    END IF;
END $EF$;
COMMIT;

