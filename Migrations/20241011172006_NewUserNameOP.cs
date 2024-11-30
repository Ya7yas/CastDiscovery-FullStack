using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScenePro.Migrations
{
    /// <inheritdoc />
    public partial class NewUserNameOP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "OrganizationPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "OrganizationPortfolios");
        }
    }
}
