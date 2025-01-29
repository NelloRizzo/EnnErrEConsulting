using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nr.BusinessLayer.EF.Migrations
{
    /// <inheritdoc />
    public partial class PostalAddressFieldNameChanged_AttachmentLinkAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "PostalAddresses",
                newName: "Street");

            migrationBuilder.CreateTable(
                name: "LinkEntity",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MimeType = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_LinkEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_LinkId",
                table: "Attachments",
                column: "LinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_LinkEntity_LinkId",
                table: "Attachments",
                column: "LinkId",
                principalTable: "LinkEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_LinkEntity_LinkId",
                table: "Attachments");

            migrationBuilder.DropTable(
                name: "LinkEntity");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_LinkId",
                table: "Attachments");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "PostalAddresses",
                newName: "Address");
        }
    }
}
