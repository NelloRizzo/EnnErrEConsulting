using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nr.BusinessLayer.EF.Migrations
{
    /// <inheritdoc />
    public partial class PecModifiedInCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Emails_PecId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_PecId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "PecId",
                table: "Companies");

            migrationBuilder.AddColumn<string>(
                name: "Pec",
                table: "Companies",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropColumn(
                name: "Pec",
                table: "Companies");

            migrationBuilder.AddColumn<int>(
                name: "PecId",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_PecId",
                table: "Companies",
                column: "PecId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Emails_PecId",
                table: "Companies",
                column: "PecId",
                principalTable: "Emails",
                principalColumn: "Id");
        }
    }
}
