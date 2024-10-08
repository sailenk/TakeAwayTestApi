using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakeAwayTestApi.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "SavedListings");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "SavedListings");

            migrationBuilder.DropColumn(
                name: "Postcode",
                table: "SavedListings");

            migrationBuilder.DropColumn(
                name: "State",
                table: "SavedListings");

            migrationBuilder.RenameColumn(
                name: "Suburb",
                table: "SavedListings",
                newName: "DateAdded");

            migrationBuilder.AddColumn<bool>(
                name: "IsShortListed",
                table: "SavedListings",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "SavedListings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShortListed",
                table: "SavedListings");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "SavedListings");

            migrationBuilder.RenameColumn(
                name: "DateAdded",
                table: "SavedListings",
                newName: "Suburb");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "SavedListings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "SavedListings",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Postcode",
                table: "SavedListings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "SavedListings",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
