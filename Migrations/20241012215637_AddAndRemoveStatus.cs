using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScenePro.Migrations
{
    /// <inheritdoc />
    public partial class AddAndRemoveStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Talents");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "Talents");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "TalentPortfolios");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "OrganizationPortfolios");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Talents",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "ConfirmPassword",
                table: "Organizations",
                newName: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Talents",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Organizations",
                newName: "ConfirmPassword");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Talents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "Talents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "TalentPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Organizations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "OrganizationPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
