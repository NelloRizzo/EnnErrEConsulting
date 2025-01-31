using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nr.BusinessLayer.EF.Migrations
{
    /// <inheritdoc />
    public partial class InnerTopicsOrdered : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Tags_TagEntityId",
                table: "Topics");

            migrationBuilder.DropTable(
                name: "TopicEntityTopicEntity");

            migrationBuilder.DropIndex(
                name: "IX_Topics_TagEntityId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "TagEntityId",
                table: "Topics");

            migrationBuilder.CreateTable(
                name: "InnerTopics",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InnerTopicId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_InnerTopics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InnerTopics_Topics_InnerTopicId",
                        column: x => x.InnerTopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagEntityTopicEntity",
                columns: table => new {
                    TagsId = table.Column<int>(type: "int", nullable: false),
                    TopicsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_TagEntityTopicEntity", x => new { x.TagsId, x.TopicsId });
                    table.ForeignKey(
                        name: "FK_TagEntityTopicEntity_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagEntityTopicEntity_Topics_TopicsId",
                        column: x => x.TopicsId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InnerTopics_InnerTopicId",
                table: "InnerTopics",
                column: "InnerTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_TagEntityTopicEntity_TopicsId",
                table: "TagEntityTopicEntity",
                column: "TopicsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "InnerTopics");

            migrationBuilder.DropTable(
                name: "TagEntityTopicEntity");

            migrationBuilder.AddColumn<int>(
                name: "TagEntityId",
                table: "Topics",
                type: "int",
                nullable: true);

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
                name: "IX_Topics_TagEntityId",
                table: "Topics",
                column: "TagEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicEntityTopicEntity_TopicsId",
                table: "TopicEntityTopicEntity",
                column: "TopicsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Tags_TagEntityId",
                table: "Topics",
                column: "TagEntityId",
                principalTable: "Tags",
                principalColumn: "Id");
        }
    }
}
