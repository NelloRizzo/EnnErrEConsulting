using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nr.BusinessLayer.EF.Migrations
{
    /// <inheritdoc />
    public partial class MultipleUsersLinkedToCustomersUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Customers_CustomerEntityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CustomerEntityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CustomerEntityId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "CustomerUserRelationship",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerUserRelationship", x => new { x.CustomerId, x.UserId });
                    table.ForeignKey(
                        name: "FK_CustomerUserRelationship_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerUserRelationship_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerUserRelationship_UserId",
                table: "CustomerUserRelationship",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerUserRelationship");

            migrationBuilder.AddColumn<int>(
                name: "CustomerEntityId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CustomerEntityId",
                table: "Users",
                column: "CustomerEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Customers_CustomerEntityId",
                table: "Users",
                column: "CustomerEntityId",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
