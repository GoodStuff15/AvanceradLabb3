using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AvanceradLabb3.Migrations
{
    /// <inheritdoc />
    public partial class rebuildmanymany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hyperlinks_PersonInterests_PersonInterestPersonId_PersonInterestInterestId",
                table: "Hyperlinks");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInterests_Interests_InterestId",
                table: "PersonInterests");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInterests_People_PersonId",
                table: "PersonInterests");

            migrationBuilder.DropTable(
                name: "InterestPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonInterests",
                table: "PersonInterests");

            migrationBuilder.RenameTable(
                name: "PersonInterests",
                newName: "PersonInterest");

            migrationBuilder.RenameIndex(
                name: "IX_PersonInterests_InterestId",
                table: "PersonInterest",
                newName: "IX_PersonInterest_InterestId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Hyperlinks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonInterest",
                table: "PersonInterest",
                columns: new[] { "PersonId", "InterestId" });

            migrationBuilder.InsertData(
                table: "PersonInterest",
                columns: new[] { "InterestId", "PersonId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 3, 3 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Hyperlinks_PersonInterest_PersonInterestPersonId_PersonInterestInterestId",
                table: "Hyperlinks",
                columns: new[] { "PersonInterestPersonId", "PersonInterestInterestId" },
                principalTable: "PersonInterest",
                principalColumns: new[] { "PersonId", "InterestId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInterest_Interests_InterestId",
                table: "PersonInterest",
                column: "InterestId",
                principalTable: "Interests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInterest_People_PersonId",
                table: "PersonInterest",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hyperlinks_PersonInterest_PersonInterestPersonId_PersonInterestInterestId",
                table: "Hyperlinks");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInterest_Interests_InterestId",
                table: "PersonInterest");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInterest_People_PersonId",
                table: "PersonInterest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonInterest",
                table: "PersonInterest");

            migrationBuilder.DeleteData(
                table: "PersonInterest",
                keyColumns: new[] { "InterestId", "PersonId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PersonInterest",
                keyColumns: new[] { "InterestId", "PersonId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "PersonInterest",
                keyColumns: new[] { "InterestId", "PersonId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "PersonInterest",
                keyColumns: new[] { "InterestId", "PersonId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.RenameTable(
                name: "PersonInterest",
                newName: "PersonInterests");

            migrationBuilder.RenameIndex(
                name: "IX_PersonInterest_InterestId",
                table: "PersonInterests",
                newName: "IX_PersonInterests_InterestId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Hyperlinks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonInterests",
                table: "PersonInterests",
                columns: new[] { "PersonId", "InterestId" });

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

            migrationBuilder.CreateIndex(
                name: "IX_InterestPerson_PeopleId",
                table: "InterestPerson",
                column: "PeopleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hyperlinks_PersonInterests_PersonInterestPersonId_PersonInterestInterestId",
                table: "Hyperlinks",
                columns: new[] { "PersonInterestPersonId", "PersonInterestInterestId" },
                principalTable: "PersonInterests",
                principalColumns: new[] { "PersonId", "InterestId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInterests_Interests_InterestId",
                table: "PersonInterests",
                column: "InterestId",
                principalTable: "Interests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInterests_People_PersonId",
                table: "PersonInterests",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
