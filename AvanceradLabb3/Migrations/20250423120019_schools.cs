using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AvanceradLabb3.Migrations
{
    /// <inheritdoc />
    public partial class schools : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LinkCollection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkCollection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hyperlink",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkCollectionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hyperlink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hyperlink_LinkCollection_LinkCollectionId",
                        column: x => x.LinkCollectionId,
                        principalTable: "LinkCollection",
                        principalColumn: "Id");
                });

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

            migrationBuilder.InsertData(
                table: "Hyperlink",
                columns: new[] { "Id", "LinkCollectionId", "Title", "Url" },
                values: new object[,]
                {
                    { 1, null, "Scryfall", "http://www.scryfall.com" },
                    { 2, null, "Biltema", "http://www.biltema.com" }
                });

            migrationBuilder.InsertData(
                table: "LinkCollection",
                column: "Id",
                values: new object[]
                {
                    1,
                    2,
                    3,
                    4
                });

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "vd@swedbonk.se");

            migrationBuilder.CreateIndex(
                name: "IX_Hyperlink_LinkCollectionId",
                table: "Hyperlink",
                column: "LinkCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_HyperlinkInterest_LinksId",
                table: "HyperlinkInterest",
                column: "LinksId");

            migrationBuilder.CreateIndex(
                name: "IX_HyperlinkPerson_PeopleId",
                table: "HyperlinkPerson",
                column: "PeopleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HyperlinkInterest");

            migrationBuilder.DropTable(
                name: "HyperlinkPerson");

            migrationBuilder.DropTable(
                name: "Hyperlink");

            migrationBuilder.DropTable(
                name: "LinkCollection");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "gustav@swedbonk.se");
        }
    }
}
