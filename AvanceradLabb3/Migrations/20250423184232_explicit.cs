using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AvanceradLabb3.Migrations
{
    /// <inheritdoc />
    public partial class @explicit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hyperlink_LinkCollection_InCollectionId",
                table: "Hyperlink");

            migrationBuilder.DropTable(
                name: "LinkCollection");

            migrationBuilder.RenameColumn(
                name: "InCollectionId",
                table: "Hyperlink",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Hyperlink_InCollectionId",
                table: "Hyperlink",
                newName: "IX_Hyperlink_PersonId");

            migrationBuilder.AddColumn<int>(
                name: "InterestId",
                table: "Hyperlink",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Hyperlink",
                keyColumn: "Id",
                keyValue: 1,
                column: "InterestId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hyperlink",
                keyColumn: "Id",
                keyValue: 2,
                column: "InterestId",
                value: null);

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
                name: "FK_Hyperlink_People_PersonId",
                table: "Hyperlink");

            migrationBuilder.DropIndex(
                name: "IX_Hyperlink_InterestId",
                table: "Hyperlink");

            migrationBuilder.DropColumn(
                name: "InterestId",
                table: "Hyperlink");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Hyperlink",
                newName: "InCollectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Hyperlink_PersonId",
                table: "Hyperlink",
                newName: "IX_Hyperlink_InCollectionId");

            migrationBuilder.CreateTable(
                name: "LinkCollection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestId = table.Column<int>(type: "int", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkCollection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkCollection_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LinkCollection_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "LinkCollection",
                columns: new[] { "Id", "InterestId", "PersonId" },
                values: new object[,]
                {
                    { 1, null, null },
                    { 2, null, null },
                    { 3, null, null },
                    { 4, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LinkCollection_InterestId",
                table: "LinkCollection",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkCollection_PersonId",
                table: "LinkCollection",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hyperlink_LinkCollection_InCollectionId",
                table: "Hyperlink",
                column: "InCollectionId",
                principalTable: "LinkCollection",
                principalColumn: "Id");
        }
    }
}
