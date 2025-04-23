using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvanceradLabb3.Migrations
{
    /// <inheritdoc />
    public partial class linkCollection : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_Hyperlink_InterestId",
                table: "Hyperlink");

            migrationBuilder.DropIndex(
                name: "IX_Hyperlink_PersonId",
                table: "Hyperlink");

            migrationBuilder.DropColumn(
                name: "InterestId",
                table: "Hyperlink");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Hyperlink");

            migrationBuilder.AddColumn<int>(
                name: "InterestId",
                table: "LinkCollection",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "LinkCollection",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "LinkCollection",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "LinkCollection",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "LinkCollection",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "LinkCollection",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_LinkCollection_InterestId",
                table: "LinkCollection",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkCollection_PersonId",
                table: "LinkCollection",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkCollection_Interests_InterestId",
                table: "LinkCollection",
                column: "InterestId",
                principalTable: "Interests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LinkCollection_People_PersonId",
                table: "LinkCollection",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LinkCollection_Interests_InterestId",
                table: "LinkCollection");

            migrationBuilder.DropForeignKey(
                name: "FK_LinkCollection_People_PersonId",
                table: "LinkCollection");

            migrationBuilder.DropIndex(
                name: "IX_LinkCollection_InterestId",
                table: "LinkCollection");

            migrationBuilder.DropIndex(
                name: "IX_LinkCollection_PersonId",
                table: "LinkCollection");

            migrationBuilder.DropColumn(
                name: "InterestId",
                table: "LinkCollection");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "LinkCollection");

            migrationBuilder.AddColumn<int>(
                name: "InterestId",
                table: "Hyperlink",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Hyperlink",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Hyperlink",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Hyperlink",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "InterestId", "PersonId" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Hyperlink_InterestId",
                table: "Hyperlink",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_Hyperlink_PersonId",
                table: "Hyperlink",
                column: "PersonId");

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
