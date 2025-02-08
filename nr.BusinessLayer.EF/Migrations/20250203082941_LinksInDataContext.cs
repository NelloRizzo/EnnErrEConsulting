using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nr.BusinessLayer.EF.Migrations
{
    /// <inheritdoc />
    public partial class LinksInDataContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_LinkEntity_LinkId",
                table: "Attachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LinkEntity",
                table: "LinkEntity");

            migrationBuilder.RenameTable(
                name: "LinkEntity",
                newName: "Links");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Links",
                table: "Links",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Links_LinkId",
                table: "Attachments",
                column: "LinkId",
                principalTable: "Links",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Links_LinkId",
                table: "Attachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Links",
                table: "Links");

            migrationBuilder.RenameTable(
                name: "Links",
                newName: "LinkEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LinkEntity",
                table: "LinkEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_LinkEntity_LinkId",
                table: "Attachments",
                column: "LinkId",
                principalTable: "LinkEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
