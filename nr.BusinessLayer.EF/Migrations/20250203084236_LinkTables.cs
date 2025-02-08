using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nr.BusinessLayer.EF.Migrations
{
    /// <inheritdoc />
    public partial class LinkTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable(
                name: "ContentLinks",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", maxLength: 1000000, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_ContentLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentLinks_Links_Id",
                        column: x => x.Id,
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UrlLinks",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_UrlLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UrlLinks_Links_Id",
                        column: x => x.Id,
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IDX_LINKURL_UNIQUE",
                table: "UrlLinks",
                column: "Url",
                unique: true,
                filter: "[Url] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "ContentLinks");

            migrationBuilder.DropTable(
                name: "UrlLinks");
        }
    }
}
