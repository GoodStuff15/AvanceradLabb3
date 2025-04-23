using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvanceradLabb3.Migrations
{
    /// <inheritdoc />
    public partial class fudge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hyperlink_LinkCollection_LinkCollectionId",
                table: "Hyperlink");

            migrationBuilder.DropTable(
                name: "HyperlinkInterest");

            migrationBuilder.DropTable(
                name: "HyperlinkPerson");

            migrationBuilder.RenameColumn(
                name: "LinkCollectionId",
                table: "Hyperlink",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Hyperlink_LinkCollectionId",
                table: "Hyperlink",
                newName: "IX_Hyperlink_PersonId");

            migrationBuilder.AddColumn<int>(
                name: "InCollectionId",
                table: "Hyperlink",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InterestId",
                table: "Hyperlink",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Hyperlink",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InCollectionId", "InterestId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Hyperlink",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InCollectionId", "InterestId" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Hyperlink_InCollectionId",
                table: "Hyperlink",
                column: "InCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Hyperlink_InterestId",
                table: "Hyperlink",
                column: "InterestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hyperlink_Interests_InterestId",
                table: "Hyperlink",
                column: "InterestId",
                principalTable: "Interests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hyperlink_LinkCollection_InCollectionId",
                table: "Hyperlink",
                column: "InCollectionId",
                principalTable: "LinkCollection",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hyperlink_People_PersonId",
                table: "Hyperlink",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hyperlink_Interests_InterestId",
                table: "Hyperlink");

            migrationBuilder.DropForeignKey(
                name: "FK_Hyperlink_LinkCollection_InCollectionId",
                table: "Hyperlink");

            migrationBuilder.DropForeignKey(
                name: "FK_Hyperlink_People_PersonId",
                table: "Hyperlink");

            migrationBuilder.DropIndex(
                name: "IX_Hyperlink_InCollectionId",
                table: "Hyperlink");

            migrationBuilder.DropIndex(
                name: "IX_Hyperlink_InterestId",
                table: "Hyperlink");

            migrationBuilder.DropColumn(
                name: "InCollectionId",
                table: "Hyperlink");

            migrationBuilder.DropColumn(
                name: "InterestId",
                table: "Hyperlink");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Hyperlink",
                newName: "LinkCollectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Hyperlink_PersonId",
                table: "Hyperlink",
                newName: "IX_Hyperlink_LinkCollectionId");

            migrationBuilder.CreateTable(
                name: "HyperlinkInterest",
                columns: table => new
                {
                    InterestsId = table.Column<int>(type: "int", nullable: false),
                    LinksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HyperlinkInterest", x => new { x.InterestsId, x.LinksId });
                    table.ForeignKey(
                        name: "FK_HyperlinkInterest_Hyperlink_LinksId",
                        column: x => x.LinksId,
                        principalTable: "Hyperlink",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HyperlinkInterest_Interests_InterestsId",
                        column: x => x.InterestsId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HyperlinkPerson",
                columns: table => new
                {
                    LinksId = table.Column<int>(type: "int", nullable: false),
                    PeopleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HyperlinkPerson", x => new { x.LinksId, x.PeopleId });
                    table.ForeignKey(
                        name: "FK_HyperlinkPerson_Hyperlink_LinksId",
                        column: x => x.LinksId,
                        principalTable: "Hyperlink",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HyperlinkPerson_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HyperlinkInterest_LinksId",
                table: "HyperlinkInterest",
                column: "LinksId");

            migrationBuilder.CreateIndex(
                name: "IX_HyperlinkPerson_PeopleId",
                table: "HyperlinkPerson",
                column: "PeopleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hyperlink_LinkCollection_LinkCollectionId",
                table: "Hyperlink",
                column: "LinkCollectionId",
                principalTable: "LinkCollection",
                principalColumn: "Id");
        }
    }
}
