CREATE EXTENSION IF NOT EXISTS pgcrypto;

-- ----------------------------------------------------------------------------
-- Timestamp trigger function (sets created_at on INSERT, updated_at on INSERT/UPDATE)
-- ----------------------------------------------------------------------------
CREATE OR REPLACE FUNCTION set_timestamps()
RETURNS TRIGGER
LANGUAGE plpgsql
AS $$
BEGIN
  IF TG_OP = 'INSERT' THEN
    NEW.created_at := COALESCE(NEW.created_at, now());
    NEW.updated_at := COALESCE(NEW.updated_at, now());
  ELSE
    NEW.updated_at := now();
  END IF;
  RETURN NEW;
END;
$$;

-- ===================================
-- profiles
-- ===================================
CREATE TABLE IF NOT EXISTS profiles (
  profile_id   UUID        NOT NULL DEFAULT gen_random_uuid(),
  profile_name TEXT        NOT NULL,
  is_deleted   BOOLEAN     NOT NULL DEFAULT FALSE,
  created_at   TIMESTAMPTZ NOT NULL DEFAULT now(),
  updated_at   TIMESTAMPTZ NOT NULL DEFAULT now(),
  CONSTRAINT profile_pkey PRIMARY KEY (profile_id)
);
 
DROP TRIGGER IF EXISTS set_timestamps_on_profile ON profiles;
CREATE TRIGGER set_timestamps_on_profile
BEFORE INSERT OR UPDATE ON profiles
FOR EACH ROW EXECUTE FUNCTION set_timestamps(); 

-- ===================================
-- profile_settings
-- ===================================
CREATE TABLE IF NOT EXISTS profile_settings (
  profile_settings_id UUID        NOT NULL DEFAULT gen_random_uuid(),
  profile_id          UUID        NOT NULL,
  is_deleted          BOOLEAN     NOT NULL DEFAULT FALSE,
  created_at          TIMESTAMPTZ NOT NULL DEFAULT now(),
  updated_at          TIMESTAMPTZ NOT NULL DEFAULT now(),
  CONSTRAINT profile_settings_pkey PRIMARY KEY (profile_settings_id),
  CONSTRAINT profile_settings_profile_id_fkey
    FOREIGN KEY (profile_id) REFERENCES profiles (profile_id) ON DELETE RESTRICT
);
DROP TRIGGER IF EXISTS set_timestamps_on_profile_settings ON profile_settings;
CREATE TRIGGER set_timestamps_on_profile_settings
BEFORE INSERT OR UPDATE ON profile_settings
FOR EACH ROW EXECUTE FUNCTION set_timestamps();


-- ===================================
-- profile_setting_options
-- ===================================
CREATE TABLE IF NOT EXISTS profile_setting_options (
  profile_setting_option_id UUID        NOT NULL DEFAULT gen_random_uuid(),
  profile_settings_id       UUID        NOT NULL,
  option_key                TEXT        NOT NULL,
  option_value              TEXT        NOT NULL,
  is_deleted                BOOLEAN     NOT NULL DEFAULT FALSE,
  created_at                TIMESTAMPTZ NOT NULL DEFAULT now(),
  updated_at                TIMESTAMPTZ NOT NULL DEFAULT now(),
  CONSTRAINT profile_setting_option_pkey PRIMARY KEY (profile_setting_option_id),
  CONSTRAINT profile_setting_option_settings_fkey
    FOREIGN KEY (profile_settings_id)
    REFERENCES profile_settings (profile_settings_id) ON DELETE RESTRICT
);
DROP TRIGGER IF EXISTS set_timestamps_on_profile_setting_option ON profile_setting_options;
CREATE TRIGGER set_timestamps_on_profile_setting_option
BEFORE INSERT OR UPDATE ON profile_setting_options
FOR EACH ROW EXECUTE FUNCTION set_timestamps();

-- ===================================
-- chat_rooms
-- ===================================
CREATE TABLE IF NOT EXISTS chat_rooms (
  chat_room_id   UUID        NOT NULL DEFAULT gen_random_uuid(),
  chat_room_name TEXT        NOT NULL,
  is_deleted     BOOLEAN     NOT NULL DEFAULT FALSE,
  created_at     TIMESTAMPTZ NOT NULL DEFAULT now(),
  updated_at     TIMESTAMPTZ NOT NULL DEFAULT now(),
  CONSTRAINT chat_room_pkey PRIMARY KEY (chat_room_id)
);
 
DROP TRIGGER IF EXISTS set_timestamps_on_chat_room ON chat_rooms;
CREATE TRIGGER set_timestamps_on_chat_room
BEFORE INSERT OR UPDATE ON chat_rooms
FOR EACH ROW EXECUTE FUNCTION set_timestamps();
 

-- ===================================
-- chat_room_members
-- ===================================
CREATE TABLE IF NOT EXISTS chat_room_members (
  chat_room_member_id UUID        NOT NULL DEFAULT gen_random_uuid(),
  chat_room_id        UUID        NOT NULL,
  profile_id          UUID        NOT NULL,
  is_deleted          BOOLEAN     NOT NULL DEFAULT FALSE,
  created_at          TIMESTAMPTZ NOT NULL DEFAULT now(),
  updated_at          TIMESTAMPTZ NOT NULL DEFAULT now(),
  CONSTRAINT chat_room_member_pkey PRIMARY KEY (chat_room_member_id),
  CONSTRAINT chat_room_member_chat_room_id_fkey
    FOREIGN KEY (chat_room_id) REFERENCES chat_rooms (chat_room_id) ON DELETE RESTRICT,
  CONSTRAINT chat_room_member_profile_id_fkey
    FOREIGN KEY (profile_id)   REFERENCES profiles   (profile_id)   ON DELETE RESTRICT
);
 
DROP TRIGGER IF EXISTS set_timestamps_on_chat_room_member ON chat_room_members;
CREATE TRIGGER set_timestamps_on_chat_room_member
BEFORE INSERT OR UPDATE ON chat_room_members
FOR EACH ROW EXECUTE FUNCTION set_timestamps();
   


-- ===================================
-- chat_room_messages
-- ===================================
CREATE TABLE IF NOT EXISTS chat_room_messages (
  chat_room_message_id UUID        NOT NULL DEFAULT gen_random_uuid(),
  profile_id           UUID        NOT NULL,
  chat_room_id         UUID        NOT NULL,
  message_text         TEXT        NOT NULL,
  is_deleted           BOOLEAN     NOT NULL DEFAULT FALSE,
  created_at           TIMESTAMPTZ NOT NULL DEFAULT now(),
  updated_at           TIMESTAMPTZ NOT NULL DEFAULT now(),
  CONSTRAINT chat_room_message_pkey PRIMARY KEY (chat_room_message_id),
  CONSTRAINT chat_room_message_profile_id_fkey
    FOREIGN KEY (profile_id)   REFERENCES profiles   (profile_id)   ON DELETE RESTRICT,
  CONSTRAINT chat_room_message_chat_room_id_fkey
    FOREIGN KEY (chat_room_id) REFERENCES chat_rooms (chat_room_id) ON DELETE RESTRICT
);
 
DROP TRIGGER IF EXISTS set_timestamps_on_chat_room_message ON chat_room_messages;
CREATE TRIGGER set_timestamps_on_chat_room_message
BEFORE INSERT OR UPDATE ON chat_room_messages
FOR EACH ROW EXECUTE FUNCTION set_timestamps();
  
-- ===================================
-- languages
-- ===================================
CREATE TABLE IF NOT EXISTS languages (
  language_id   UUID        NOT NULL DEFAULT gen_random_uuid(),
  language_name TEXT        NOT NULL,
  is_deleted    BOOLEAN     NOT NULL DEFAULT FALSE,
  created_at    TIMESTAMPTZ NOT NULL DEFAULT now(),
  updated_at    TIMESTAMPTZ NOT NULL DEFAULT now(),
  CONSTRAINT languages_pkey PRIMARY KEY (language_id)
);
 
DROP TRIGGER IF EXISTS set_timestamps_on_languages ON languages;
CREATE TRIGGER set_timestamps_on_languages
BEFORE INSERT OR UPDATE ON languages
FOR EACH ROW EXECUTE FUNCTION set_timestamps();
 
-- ===================================
-- language_translations
-- ===================================

CREATE TABLE IF NOT EXISTS language_translations (
  language_translation_id UUID        NOT NULL DEFAULT gen_random_uuid(),
  from_language_id        UUID        NOT NULL,
  to_language_id          UUID        NOT NULL,
  from_language_text      TEXT        NOT NULL,
  to_language_text        TEXT        NOT NULL,
  is_deleted              BOOLEAN     NOT NULL DEFAULT FALSE,
  created_at              TIMESTAMPTZ NOT NULL DEFAULT now(),
  updated_at              TIMESTAMPTZ NOT NULL DEFAULT now(),
  CONSTRAINT language_translation_pkey PRIMARY KEY (language_translation_id),
  CONSTRAINT language_translation_from_lang_fkey FOREIGN KEY (from_language_id)
    REFERENCES languages (language_id) ON DELETE RESTRICT,
  CONSTRAINT language_translation_to_lang_fkey FOREIGN KEY (to_language_id)
    REFERENCES languages (language_id) ON DELETE RESTRICT
);
DROP TRIGGER IF EXISTS set_timestamps_on_language_translation ON language_translations;
CREATE TRIGGER set_timestamps_on_language_translation
BEFORE INSERT OR UPDATE ON language_translations
FOR EACH ROW EXECUTE FUNCTION set_timestamps();

-- ===================================
-- language_word_frequencies
-- ===================================
CREATE TABLE IF NOT EXISTS language_word_frequencies (
  language_word_frequency_id UUID        NOT NULL DEFAULT gen_random_uuid(),
  language_id                UUID        NOT NULL,
  language_translation_id    UUID        NOT NULL,
  frequency_rank             INTEGER     NOT NULL,
  is_deleted                 BOOLEAN     NOT NULL DEFAULT FALSE,
  created_at                 TIMESTAMPTZ NOT NULL DEFAULT now(),
  updated_at                 TIMESTAMPTZ NOT NULL DEFAULT now(),
  CONSTRAINT language_word_frequency_pkey PRIMARY KEY (language_word_frequency_id),
  CONSTRAINT lwf_language_fkey FOREIGN KEY (language_id)
    REFERENCES languages (language_id) ON DELETE RESTRICT,
  CONSTRAINT lwf_translation_fkey FOREIGN KEY (language_translation_id)
    REFERENCES language_translations (language_translation_id) ON DELETE RESTRICT
);
DROP TRIGGER IF EXISTS set_timestamps_on_language_word_frequency ON language_word_frequencies;
CREATE TRIGGER set_timestamps_on_language_word_frequency
BEFORE INSERT OR UPDATE ON language_word_frequencies
FOR EACH ROW EXECUTE FUNCTION set_timestamps();

-- ===================================
-- flash_card_set_templates
-- ===================================
CREATE TABLE IF NOT EXISTS flash_card_set_templates (
  flash_card_set_template_id UUID        NOT NULL DEFAULT gen_random_uuid(),
  flash_card_set_name        TEXT        NOT NULL,
  is_deleted                 BOOLEAN     NOT NULL DEFAULT FALSE,
  created_at                 TIMESTAMPTZ NOT NULL DEFAULT now(),
  updated_at                 TIMESTAMPTZ NOT NULL DEFAULT now(),
  CONSTRAINT flash_card_set_template_pkey PRIMARY KEY (flash_card_set_template_id)
);
DROP TRIGGER IF EXISTS set_timestamps_on_flash_card_set_template ON flash_card_set_templates;
CREATE TRIGGER set_timestamps_on_flash_card_set_template
BEFORE INSERT OR UPDATE ON flash_card_set_templates
FOR EACH ROW EXECUTE FUNCTION set_timestamps();


-- ===================================
-- flash_card_set_template_items
-- ===================================
CREATE TABLE IF NOT EXISTS flash_card_set_template_items (
  flash_card_set_template_item_id UUID        NOT NULL DEFAULT gen_random_uuid(),
  flash_card_set_template_id      UUID        NOT NULL,
  question                        TEXT        NOT NULL,
  is_deleted                      BOOLEAN     NOT NULL DEFAULT FALSE,
  created_at                      TIMESTAMPTZ NOT NULL DEFAULT now(),
  updated_at                      TIMESTAMPTZ NOT NULL DEFAULT now(),
  CONSTRAINT flash_card_set_template_item_pkey PRIMARY KEY (flash_card_set_template_item_id),
  CONSTRAINT fcsti_template_fkey FOREIGN KEY (flash_card_set_template_id)
    REFERENCES flash_card_set_templates (flash_card_set_template_id) ON DELETE RESTRICT
);
DROP TRIGGER IF EXISTS set_timestamps_on_flash_card_set_template_item ON flash_card_set_template_items;
CREATE TRIGGER set_timestamps_on_flash_card_set_template_item
BEFORE INSERT OR UPDATE ON flash_card_set_template_items
FOR EACH ROW EXECUTE FUNCTION set_timestamps();


-- ===================================
-- flash_card_set_template_item_options
-- ===================================
CREATE TABLE IF NOT EXISTS flash_card_set_template_item_options (
  flash_card_set_template_item_option_id UUID        NOT NULL DEFAULT gen_random_uuid(),
  flash_card_set_template_item_id        UUID        NOT NULL,
  option_key                             TEXT        NOT NULL,
  option_value                           TEXT        NOT NULL,
  is_deleted                              BOOLEAN     NOT NULL DEFAULT FALSE,
  created_at                              TIMESTAMPTZ NOT NULL DEFAULT now(),
  updated_at                              TIMESTAMPTZ NOT NULL DEFAULT now(),
  CONSTRAINT flash_card_set_template_item_option_pkey PRIMARY KEY (flash_card_set_template_item_option_id),
  CONSTRAINT fcstio_item_fkey FOREIGN KEY (flash_card_set_template_item_id)
    REFERENCES flash_card_set_template_items (flash_card_set_template_item_id) ON DELETE RESTRICT
);
DROP TRIGGER IF EXISTS set_timestamps_on_flash_card_set_template_item_option ON flash_card_set_template_item_options;
CREATE TRIGGER set_timestamps_on_flash_card_set_template_item_option
BEFORE INSERT OR UPDATE ON flash_card_set_template_item_options
FOR EACH ROW EXECUTE FUNCTION set_timestamps();


-- ===================================
-- flash_card_answers
-- ===================================
CREATE TABLE IF NOT EXISTS flash_card_answers (
  flash_card_answer_id            UUID        NOT NULL DEFAULT gen_random_uuid(),
  flash_card_set_template_item_id UUID        NOT NULL,
  profile_id                      UUID        NOT NULL,
  answer                          TEXT        NOT NULL,
  is_deleted                      BOOLEAN     NOT NULL DEFAULT FALSE,
  created_at                      TIMESTAMPTZ NOT NULL DEFAULT now(),
  updated_at                      TIMESTAMPTZ NOT NULL DEFAULT now(),
  CONSTRAINT flash_card_answer_pkey PRIMARY KEY (flash_card_answer_id),
  CONSTRAINT fca_item_fkey FOREIGN KEY (flash_card_set_template_item_id)
    REFERENCES flash_card_set_template_items (flash_card_set_template_item_id) ON DELETE RESTRICT,
  CONSTRAINT fca_profile_fkey FOREIGN KEY (profile_id)
    REFERENCES profiles (profile_id) ON DELETE RESTRICT
);
DROP TRIGGER IF EXISTS set_timestamps_on_flash_card_answer ON flash_card_answers;
CREATE TRIGGER set_timestamps_on_flash_card_answer
BEFORE INSERT OR UPDATE ON flash_card_answers
FOR EACH ROW EXECUTE FUNCTION set_timestamps();