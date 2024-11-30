using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScenePro.Migrations
{
    /// <inheritdoc />
    public partial class _2ndMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TalentsPortfolio",
                table: "TalentsPortfolio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Portfolios",
                table: "Portfolios");

            migrationBuilder.RenameTable(
                name: "TalentsPortfolio",
                newName: "TalentPortfolios");

            migrationBuilder.RenameTable(
                name: "Portfolios",
                newName: "OrganizationPortfolios");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TalentPortfolios",
                table: "TalentPortfolios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationPortfolios",
                table: "OrganizationPortfolios",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TalentPortfolios",
                table: "TalentPortfolios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationPortfolios",
                table: "OrganizationPortfolios");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "TalentPortfolios",
                newName: "TalentsPortfolio");

            migrationBuilder.RenameTable(
                name: "OrganizationPortfolios",
                newName: "Portfolios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TalentsPortfolio",
                table: "TalentsPortfolio",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Portfolios",
                table: "Portfolios",
                column: "Id");
        }
    }
}
