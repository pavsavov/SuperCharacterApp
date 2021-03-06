﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperCharacters.DataAccess.Migrations
{
    public partial class SecretIdentityCharacterRelationBugFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecretIdentities_Characters_CharacterId",
                table: "SecretIdentities");

            migrationBuilder.DropIndex(
                name: "IX_SecretIdentities_CharacterId",
                table: "SecretIdentities");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "SecretIdentities");

            migrationBuilder.AddColumn<string>(
                name: "CharacterId",
                table: "Characters",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharacterId",
                table: "Characters",
                column: "CharacterId",
                unique: true,
                filter: "[CharacterId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_SecretIdentities_CharacterId",
                table: "Characters",
                column: "CharacterId",
                principalTable: "SecretIdentities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_SecretIdentities_CharacterId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_CharacterId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Characters");

            migrationBuilder.AddColumn<string>(
                name: "CharacterId",
                table: "SecretIdentities",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SecretIdentities_CharacterId",
                table: "SecretIdentities",
                column: "CharacterId",
                unique: true,
                filter: "[CharacterId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_SecretIdentities_Characters_CharacterId",
                table: "SecretIdentities",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
