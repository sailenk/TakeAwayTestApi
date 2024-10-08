using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakeAwayTestApi.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class ManyToOneAndManyToManyRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedListings_Users_UserId",
                table: "SavedListings");

            migrationBuilder.DropIndex(
                name: "IX_SavedListings_UserId",
                table: "SavedListings");

            migrationBuilder.RenameColumn(
                name: "PropertyId",
                table: "SavedListings",
                newName: "ListingId");

            migrationBuilder.CreateTable(
                name: "UserSavedListings",
                columns: table => new
                {
                    SavedListingsId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSavedListings", x => new { x.SavedListingsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UserSavedListings_SavedListings_SavedListingsId",
                        column: x => x.SavedListingsId,
                        principalTable: "SavedListings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserSavedListings_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SavedListings_ListingId",
                table: "SavedListings",
                column: "ListingId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSavedListings_UsersId",
                table: "UserSavedListings",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedListings_Listings_ListingId",
                table: "SavedListings",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedListings_Listings_ListingId",
                table: "SavedListings");

            migrationBuilder.DropTable(
                name: "UserSavedListings");

            migrationBuilder.DropIndex(
                name: "IX_SavedListings_ListingId",
                table: "SavedListings");

            migrationBuilder.RenameColumn(
                name: "ListingId",
                table: "SavedListings",
                newName: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedListings_UserId",
                table: "SavedListings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedListings_Users_UserId",
                table: "SavedListings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
