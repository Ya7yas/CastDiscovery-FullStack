using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScenePro.Migrations
{
    /// <inheritdoc />
    public partial class Status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationPortfolios_Organizations_OrganizationId",
                table: "OrganizationPortfolios");

            migrationBuilder.DropForeignKey(
                name: "FK_TalentPortfolios_Talents_TalentId",
                table: "TalentPortfolios");

            migrationBuilder.DropIndex(
                name: "IX_TalentPortfolios_TalentId",
                table: "TalentPortfolios");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationPortfolios_OrganizationId",
                table: "OrganizationPortfolios");

            migrationBuilder.DropColumn(
                name: "TalentId",
                table: "TalentPortfolios");

            migrationBuilder.RenameColumn(
                name: "OrganizationId",
                table: "OrganizationPortfolios",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "TalentPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "TalentPortfolios");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "OrganizationPortfolios",
                newName: "OrganizationId");

            migrationBuilder.AddColumn<int>(
                name: "TalentId",
                table: "TalentPortfolios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TalentPortfolios_TalentId",
                table: "TalentPortfolios",
                column: "TalentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationPortfolios_OrganizationId",
                table: "OrganizationPortfolios",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationPortfolios_Organizations_OrganizationId",
                table: "OrganizationPortfolios",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TalentPortfolios_Talents_TalentId",
                table: "TalentPortfolios",
                column: "TalentId",
                principalTable: "Talents",
                principalColumn: "TalentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
