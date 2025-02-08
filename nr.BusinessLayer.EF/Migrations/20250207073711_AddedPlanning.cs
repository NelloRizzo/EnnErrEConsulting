using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nr.BusinessLayer.EF.Migrations
{
    /// <inheritdoc />
    public partial class AddedPlanning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoursePlannings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePlannings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursePlannings_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursePlannings_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    CoursePlanEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanDates_CoursePlannings_CoursePlanEntityId",
                        column: x => x.CoursePlanEntityId,
                        principalTable: "CoursePlannings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoursePlannings_CourseId",
                table: "CoursePlannings",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePlannings_CustomerId",
                table: "CoursePlannings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDates_CoursePlanEntityId",
                table: "PlanDates",
                column: "CoursePlanEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanDates");

            migrationBuilder.DropTable(
                name: "CoursePlannings");
        }
    }
}
