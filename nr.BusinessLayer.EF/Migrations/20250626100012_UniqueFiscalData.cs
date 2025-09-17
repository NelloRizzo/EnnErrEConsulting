using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nr.BusinessLayer.EF.Migrations
{
    /// <inheritdoc />
    public partial class UniqueFiscalData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateIndex(
                name: "IX_Companies_FiscalCode_VatCode",
                table: "Companies",
                columns: new[] { "FiscalCode", "VatCode" },
                unique: true,
                filter: "[FiscalCode] IS NOT NULL AND [VatCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Pec_Sdi",
                table: "Companies",
                columns: new[] { "Pec", "Sdi" },
                unique: true,
                filter: "[Pec] IS NOT NULL AND [Sdi] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropIndex(
                name: "IX_Companies_FiscalCode_VatCode",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_Pec_Sdi",
                table: "Companies");
        }
    }
}
