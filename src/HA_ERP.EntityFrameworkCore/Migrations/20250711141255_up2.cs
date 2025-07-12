using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HA_ERP.Migrations
{
    /// <inheritdoc />
    public partial class up2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "AppStaffs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppStaffs_UserId",
                table: "AppStaffs",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AppStaffs_AbpUsers_UserId",
                table: "AppStaffs",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppStaffs_AbpUsers_UserId",
                table: "AppStaffs");

            migrationBuilder.DropIndex(
                name: "IX_AppStaffs_UserId",
                table: "AppStaffs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AppStaffs");
        }
    }
}
