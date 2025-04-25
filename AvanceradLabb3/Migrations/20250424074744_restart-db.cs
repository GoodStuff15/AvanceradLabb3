using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AvanceradLabb3.Migrations
{
    /// <inheritdoc />
    public partial class restartdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hyperlink_Interests_InterestId",
                table: "Hyperlink");

            migrationBuilder.DropForeignKey(
                name: "FK_Hyperlink_People_PersonId",
                table: "Hyperlink");

            migrationBuilder.DropTable(
                name: "PersonInterest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hyperlink",
                table: "Hyperlink");

            migrationBuilder.RenameTable(
                name: "Hyperlink",
                newName: "Hyperlinks");

            migrationBuilder.RenameIndex(
                name: "IX_Hyperlink_PersonId",
                table: "Hyperlinks",
                newName: "IX_Hyperlinks_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Hyperlink_InterestId",
                table: "Hyperlinks",
                newName: "IX_Hyperlinks_InterestId");

            migrationBuilder.AddColumn<int>(
                name: "PersonInterestInterestId",
                table: "Hyperlinks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonInterestPersonId",
                table: "Hyperlinks",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hyperlinks",
                table: "Hyperlinks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "InterestPerson",
                columns: table => new
                {
                    InterestsId = table.Column<int>(type: "int", nullable: false),
                    PeopleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestPerson", x => new { x.InterestsId, x.PeopleId });
                    table.ForeignKey(
                        name: "FK_InterestPerson_Interests_InterestsId",
                        column: x => x.InterestsId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestPerson_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonInterests",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    InterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInterests", x => new { x.PersonId, x.InterestId });
                    table.ForeignKey(
                        name: "FK_PersonInterests_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonInterests_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Hyperlinks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PersonInterestInterestId", "PersonInterestPersonId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Hyperlinks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PersonInterestInterestId", "PersonInterestPersonId" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Hyperlinks_PersonInterestPersonId_PersonInterestInterestId",
                table: "Hyperlinks",
                columns: new[] { "PersonInterestPersonId", "PersonInterestInterestId" });

            migrationBuilder.CreateIndex(
                name: "IX_InterestPerson_PeopleId",
                table: "InterestPerson",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_InterestId",
                table: "PersonInterests",
                column: "InterestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hyperlinks_Interests_InterestId",
                table: "Hyperlinks",
                column: "InterestId",
                principalTable: "Interests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hyperlinks_People_PersonId",
                table: "Hyperlinks",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hyperlinks_PersonInterests_PersonInterestPersonId_PersonInterestInterestId",
                table: "Hyperlinks",
                columns: new[] { "PersonInterestPersonId", "PersonInterestInterestId" },
                principalTable: "PersonInterests",
                principalColumns: new[] { "PersonId", "InterestId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hyperlinks_Interests_InterestId",
                table: "Hyperlinks");

            migrationBuilder.DropForeignKey(
                name: "FK_Hyperlinks_People_PersonId",
                table: "Hyperlinks");

            migrationBuilder.DropForeignKey(
                name: "FK_Hyperlinks_PersonInterests_PersonInterestPersonId_PersonInterestInterestId",
                table: "Hyperlinks");

            migrationBuilder.DropTable(
                name: "InterestPerson");

            migrationBuilder.DropTable(
                name: "PersonInterests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hyperlinks",
                table: "Hyperlinks");

            migrationBuilder.DropIndex(
                name: "IX_Hyperlinks_PersonInterestPersonId_PersonInterestInterestId",
                table: "Hyperlinks");

            migrationBuilder.DropColumn(
                name: "PersonInterestInterestId",
                table: "Hyperlinks");

            migrationBuilder.DropColumn(
                name: "PersonInterestPersonId",
                table: "Hyperlinks");

            migrationBuilder.RenameTable(
                name: "Hyperlinks",
                newName: "Hyperlink");

            migrationBuilder.RenameIndex(
                name: "IX_Hyperlinks_PersonId",
                table: "Hyperlink",
                newName: "IX_Hyperlink_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Hyperlinks_InterestId",
                table: "Hyperlink",
                newName: "IX_Hyperlink_InterestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hyperlink",
                table: "Hyperlink",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PersonInterest",
                columns: table => new
                {
                    InterestsId = table.Column<int>(type: "int", nullable: false),
                    PeopleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInterest", x => new { x.InterestsId, x.PeopleId });
                    table.ForeignKey(
                        name: "FK_PersonInterest_Interests_InterestsId",
                        column: x => x.InterestsId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonInterest_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PersonInterest",
                columns: new[] { "InterestsId", "PeopleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterest_PeopleId",
                table: "PersonInterest",
                column: "PeopleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hyperlink_Interests_InterestId",
                table: "Hyperlink",
                column: "InterestId",
                principalTable: "Interests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Hyperlink_People_PersonId",
                table: "Hyperlink",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");
        }
    }
}
