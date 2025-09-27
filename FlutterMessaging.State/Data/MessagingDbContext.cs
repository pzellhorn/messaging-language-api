using System;
using System.Collections.Generic;
using FlutterMessaging.State.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlutterMessaging.State.Data;

public partial class MessagingDbContext : DbContext
{
    public MessagingDbContext(DbContextOptions<MessagingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<chat_room> chat_rooms { get; set; }

    public virtual DbSet<chat_room_member> chat_room_members { get; set; }

    public virtual DbSet<chat_room_message> chat_room_messages { get; set; }

    public virtual DbSet<flash_card_answer> flash_card_answers { get; set; }

    public virtual DbSet<flash_card_set_template> flash_card_set_templates { get; set; }

    public virtual DbSet<flash_card_set_template_item> flash_card_set_template_items { get; set; }

    public virtual DbSet<language_translation> language_translations { get; set; }

    public virtual DbSet<language_word_frequency> language_word_frequencies { get; set; }

    public virtual DbSet<profile> profiles { get; set; }

    public virtual DbSet<profile_setting> profile_settings { get; set; }

    public virtual DbSet<profile_setting_option> profile_setting_options { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pgcrypto");

        modelBuilder.Entity<chat_room>(entity =>
        {
            entity.HasKey(e => e.chat_room_id).HasName("chat_room_pkey");

            entity.ToTable("chat_rooms");

            entity.Property(e => e.chat_room_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.created_at).HasDefaultValueSql("now()");
            entity.Property(e => e.is_deleted).HasDefaultValue(false);
            entity.Property(e => e.updated_at).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<chat_room_member>(entity =>
        {
            entity.HasKey(e => e.chat_room_member_id).HasName("chat_room_member_pkey");

            entity.ToTable("chat_room_members");

            entity.Property(e => e.chat_room_member_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.created_at).HasDefaultValueSql("now()");
            entity.Property(e => e.is_deleted).HasDefaultValue(false);
            entity.Property(e => e.updated_at).HasDefaultValueSql("now()");

            entity.HasOne(d => d.chat_room).WithMany(p => p.chat_room_members)
                .HasForeignKey(d => d.chat_room_id)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("chat_room_member_chat_room_id_fkey");

            entity.HasOne(d => d.profile).WithMany(p => p.chat_room_members)
                .HasForeignKey(d => d.profile_id)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("chat_room_member_profile_id_fkey");
        });

        modelBuilder.Entity<chat_room_message>(entity =>
        {
            entity.HasKey(e => e.chat_room_message_id).HasName("chat_room_message_pkey");

            entity.ToTable("chat_room_messages");

            entity.Property(e => e.chat_room_message_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.created_at).HasDefaultValueSql("now()");
            entity.Property(e => e.is_deleted).HasDefaultValue(false);
            entity.Property(e => e.updated_at).HasDefaultValueSql("now()");

            entity.HasOne(d => d.chat_room).WithMany(p => p.chat_room_messages)
                .HasForeignKey(d => d.chat_room_id)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("chat_room_message_chat_room_id_fkey");

            entity.HasOne(d => d.profile).WithMany(p => p.chat_room_messages)
                .HasForeignKey(d => d.profile_id)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("chat_room_message_profile_id_fkey");
        });

        modelBuilder.Entity<flash_card_answer>(entity =>
        {
            entity.HasKey(e => e.flash_card_answer_id).HasName("flash_card_answer_pkey");

            entity.ToTable("flash_card_answers");

            entity.Property(e => e.flash_card_answer_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.created_at).HasDefaultValueSql("now()");
            entity.Property(e => e.is_deleted).HasDefaultValue(false);
            entity.Property(e => e.updated_at).HasDefaultValueSql("now()");

            entity.HasOne(d => d.flash_card_set_template_item).WithMany(p => p.flash_card_answers)
                .HasForeignKey(d => d.flash_card_set_template_item_id)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fca_item_fkey");

            entity.HasOne(d => d.profile).WithMany(p => p.flash_card_answers)
                .HasForeignKey(d => d.profile_id)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fca_profile_fkey");
        });

        modelBuilder.Entity<flash_card_set_template>(entity =>
        {
            entity.HasKey(e => e.flash_card_set_template_id).HasName("flash_card_set_template_pkey");

            entity.ToTable("flash_card_set_templates");

            entity.Property(e => e.flash_card_set_template_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.created_at).HasDefaultValueSql("now()");
            entity.Property(e => e.is_deleted).HasDefaultValue(false);
            entity.Property(e => e.updated_at).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<flash_card_set_template_item>(entity =>
        {
            entity.HasKey(e => e.flash_card_set_template_item_id).HasName("flash_card_set_template_item_pkey");

            entity.ToTable("flash_card_set_template_items");

            entity.Property(e => e.flash_card_set_template_item_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.created_at).HasDefaultValueSql("now()");
            entity.Property(e => e.is_deleted).HasDefaultValue(false);
            entity.Property(e => e.updated_at).HasDefaultValueSql("now()");

            entity.HasOne(d => d.flash_card_set_template).WithMany(p => p.flash_card_set_template_items)
                .HasForeignKey(d => d.flash_card_set_template_id)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fcsti_template_fkey");
        });

        modelBuilder.Entity<language_translation>(entity =>
        {
            entity.HasKey(e => e.language_translation_id).HasName("language_translation_pkey");

            entity.ToTable("language_translations");

            entity.Property(e => e.language_translation_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.created_at).HasDefaultValueSql("now()");
            entity.Property(e => e.is_deleted).HasDefaultValue(false);
            entity.Property(e => e.updated_at).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<language_word_frequency>(entity =>
        {
            entity.HasKey(e => e.language_word_frequency_id).HasName("language_word_frequency_pkey");

            entity.ToTable("language_word_frequencies");

            entity.Property(e => e.language_word_frequency_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.created_at).HasDefaultValueSql("now()");
            entity.Property(e => e.is_deleted).HasDefaultValue(false);
            entity.Property(e => e.updated_at).HasDefaultValueSql("now()");

            entity.HasOne(d => d.language_translation).WithMany(p => p.language_word_frequencies)
                .HasForeignKey(d => d.language_translation_id)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("lwf_translation_fkey");
        });

        modelBuilder.Entity<profile>(entity =>
        {
            entity.HasKey(e => e.profile_id).HasName("profile_pkey");

            entity.ToTable("profiles");

            entity.Property(e => e.profile_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.created_at).HasDefaultValueSql("now()");
            entity.Property(e => e.is_deleted).HasDefaultValue(false);
            entity.Property(e => e.updated_at).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<profile_setting>(entity =>
        {
            entity.HasKey(e => e.profile_settings_id).HasName("profile_settings_pkey");

            entity.ToTable("profile_settings");

            entity.Property(e => e.profile_settings_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.created_at).HasDefaultValueSql("now()");
            entity.Property(e => e.is_deleted).HasDefaultValue(false);
            entity.Property(e => e.updated_at).HasDefaultValueSql("now()");

            entity.HasOne(d => d.profile).WithMany(p => p.profile_settings)
                .HasForeignKey(d => d.profile_id)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("profile_settings_profile_id_fkey");
        });

        modelBuilder.Entity<profile_setting_option>(entity =>
        {
            entity.HasKey(e => e.profile_setting_option_id).HasName("profile_setting_option_pkey");

            entity.ToTable("profile_setting_options");

            entity.Property(e => e.profile_setting_option_id).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.created_at).HasDefaultValueSql("now()");
            entity.Property(e => e.is_deleted).HasDefaultValue(false);
            entity.Property(e => e.updated_at).HasDefaultValueSql("now()");

            entity.HasOne(d => d.profile_settings).WithMany(p => p.profile_setting_options)
                .HasForeignKey(d => d.profile_settings_id)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("profile_setting_option_settings_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
