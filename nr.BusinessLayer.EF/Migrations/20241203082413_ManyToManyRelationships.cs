using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nr.BusinessLayer.EF.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachments_Tags_TagEntityId",
                table: "Attachments");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Topics_TopicEntityId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Topics_TopicEntityId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Attachments_TagEntityId",
                table: "Attachments");

            migrationBuilder.DropColumn(
                name: "TopicEntityId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "TagEntityId",
                table: "Attachments");

            migrationBuilder.CreateTable(
                name: "AttachmentEntityTagEntity",
                columns: table => new {
                    AttachmentsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_AttachmentEntityTagEntity", x => new { x.AttachmentsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_AttachmentEntityTagEntity_Attachments_AttachmentsId",
                        column: x => x.AttachmentsId,
                        principalTable: "Attachments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttachmentEntityTagEntity_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopicEntityTopicEntity",
                columns: table => new {
                    InnerTopicsId = table.Column<int>(type: "int", nullable: false),
                    TopicsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_TopicEntityTopicEntity", x => new { x.InnerTopicsId, x.TopicsId });
                    table.ForeignKey(
                        name: "FK_TopicEntityTopicEntity_Topics_InnerTopicsId",
                        column: x => x.InnerTopicsId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicEntityTopicEntity_Topics_TopicsId",
                        column: x => x.TopicsId,
                        principalTable: "Topics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttachmentEntityTagEntity_TagsId",
                table: "AttachmentEntityTagEntity",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicEntityTopicEntity_TopicsId",
                table: "TopicEntityTopicEntity",
                column: "TopicsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "AttachmentEntityTagEntity");

            migrationBuilder.DropTable(
                name: "TopicEntityTopicEntity");

            migrationBuilder.AddColumn<int>(
                name: "TopicEntityId",
                table: "Topics",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TagEntityId",
                table: "Attachments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topics_TopicEntityId",
                table: "Topics",
                column: "TopicEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_TagEntityId",
                table: "Attachments",
                column: "TagEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Tags_TagEntityId",
                table: "Attachments",
                column: "TagEntityId",
                principalTable: "Tags",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Topics_TopicEntityId",
                table: "Topics",
                column: "TopicEntityId",
                principalTable: "Topics",
                principalColumn: "Id");
        }
    }
}
