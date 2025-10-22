using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlutterMessaging.State.Migrations
{
    /// <inheritdoc />
    public partial class jwtRefresh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "device_id",
                table: "sessions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "last_seen_at",
                table: "sessions",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "device_id",
                table: "sessions");

            migrationBuilder.DropColumn(
                name: "last_seen_at",
                table: "sessions");
        }
    }
}
