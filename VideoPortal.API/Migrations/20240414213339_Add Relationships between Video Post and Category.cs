using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoPortal.API.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationshipsbetweenVideoPostandCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoPosts_Categories_CategoryId",
                table: "VideoPosts");

            migrationBuilder.DropIndex(
                name: "IX_VideoPosts_CategoryId",
                table: "VideoPosts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "VideoPosts");

            migrationBuilder.CreateTable(
                name: "CategoryVideoPost",
                columns: table => new
                {
                    CategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VideoPostsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryVideoPost", x => new { x.CategoriesId, x.VideoPostsId });
                    table.ForeignKey(
                        name: "FK_CategoryVideoPost_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryVideoPost_VideoPosts_VideoPostsId",
                        column: x => x.VideoPostsId,
                        principalTable: "VideoPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryVideoPost_VideoPostsId",
                table: "CategoryVideoPost",
                column: "VideoPostsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryVideoPost");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "VideoPosts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VideoPosts_CategoryId",
                table: "VideoPosts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoPosts_Categories_CategoryId",
                table: "VideoPosts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
