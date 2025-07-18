using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HA_ERP.Migrations
{
    /// <inheritdoc />
    public partial class updatedata4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AppStaffs_OrganizationUnitId",
                table: "AppStaffs",
                column: "OrganizationUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppStaffs_AbpOrganizationUnits_OrganizationUnitId",
                table: "AppStaffs",
                column: "OrganizationUnitId",
                principalTable: "AbpOrganizationUnits",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppStaffs_AbpOrganizationUnits_OrganizationUnitId",
                table: "AppStaffs");

            migrationBuilder.DropIndex(
                name: "IX_AppStaffs_OrganizationUnitId",
                table: "AppStaffs");
        }
    }
}
