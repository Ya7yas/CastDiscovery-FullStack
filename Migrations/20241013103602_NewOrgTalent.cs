using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScenePro.Migrations
{
    /// <inheritdoc />
    public partial class NewOrgTalent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Talents");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Talents");

            migrationBuilder.DropColumn(
                name: "TalentDescription",
                table: "Talents");

            migrationBuilder.DropColumn(
                name: "TalentType",
                table: "Talents");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Organizations");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Talents",
                newName: "WorkSamples");

            migrationBuilder.RenameColumn(
                name: "MediaUrl",
                table: "Talents",
                newName: "Skills");

            migrationBuilder.RenameColumn(
                name: "DateJoined",
                table: "Talents",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "WebsiteURL",
                table: "Organizations",
                newName: "WebsiteUrl");

            migrationBuilder.RenameColumn(
                name: "OrgDiscribtion",
                table: "Organizations",
                newName: "Overview");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Organizations",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Organizations",
                newName: "SocialMediaLink");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Talents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Talents",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalInformation",
                table: "Talents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Awards",
                table: "Talents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Biography",
                table: "Talents",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Talents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "TalentPortfolios",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Organizations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactInfo",
                table: "Organizations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Projects",
                table: "Organizations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalInformation",
                table: "Talents");

            migrationBuilder.DropColumn(
                name: "Awards",
                table: "Talents");

            migrationBuilder.DropColumn(
                name: "Biography",
                table: "Talents");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Talents");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "ContactInfo",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "Projects",
                table: "Organizations");

            migrationBuilder.RenameColumn(
                name: "WorkSamples",
                table: "Talents",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Skills",
                table: "Talents",
                newName: "MediaUrl");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Talents",
                newName: "DateJoined");

            migrationBuilder.RenameColumn(
                name: "WebsiteUrl",
                table: "Organizations",
                newName: "WebsiteURL");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Organizations",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "SocialMediaLink",
                table: "Organizations",
                newName: "Adress");

            migrationBuilder.RenameColumn(
                name: "Overview",
                table: "Organizations",
                newName: "OrgDiscribtion");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Talents",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Talents",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Talents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Talents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TalentDescription",
                table: "Talents",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TalentType",
                table: "Talents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "TalentPortfolios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "Organizations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
