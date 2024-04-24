using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoPortal.API.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigrationforvideopostcomment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VideoPostComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VideoPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoPostComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoPostComments_IdentityUser_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VideoPostComments_VideoPosts_VideoPostId",
                        column: x => x.VideoPostId,
                        principalTable: "VideoPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoPostComments_UserId",
                table: "VideoPostComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoPostComments_VideoPostId",
                table: "VideoPostComments",
                column: "VideoPostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoPostComments");
        }
    }
}
