using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nr.BusinessLayer.EF.Migrations
{
    /// <inheritdoc />
    public partial class MultipleUsersLinkedToCustomersUpdated2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerUserRelationship_Customers_CustomerId",
                table: "CustomerUserRelationship");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerUserRelationship_Users_UserId",
                table: "CustomerUserRelationship");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerUserRelationship",
                table: "CustomerUserRelationship");

            migrationBuilder.RenameTable(
                name: "CustomerUserRelationship",
                newName: "CustomersUsers");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerUserRelationship_UserId",
                table: "CustomersUsers",
                newName: "IX_CustomersUsers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomersUsers",
                table: "CustomersUsers",
                columns: new[] { "CustomerId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersUsers_Customers_CustomerId",
                table: "CustomersUsers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomersUsers_Users_UserId",
                table: "CustomersUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomersUsers_Customers_CustomerId",
                table: "CustomersUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomersUsers_Users_UserId",
                table: "CustomersUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomersUsers",
                table: "CustomersUsers");

            migrationBuilder.RenameTable(
                name: "CustomersUsers",
                newName: "CustomerUserRelationship");

            migrationBuilder.RenameIndex(
                name: "IX_CustomersUsers_UserId",
                table: "CustomerUserRelationship",
                newName: "IX_CustomerUserRelationship_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerUserRelationship",
                table: "CustomerUserRelationship",
                columns: new[] { "CustomerId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerUserRelationship_Customers_CustomerId",
                table: "CustomerUserRelationship",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerUserRelationship_Users_UserId",
                table: "CustomerUserRelationship",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
