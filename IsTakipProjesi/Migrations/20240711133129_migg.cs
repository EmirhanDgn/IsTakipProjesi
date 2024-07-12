using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsTakipProjesi.Migrations
{
    /// <inheritdoc />
    public partial class migg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TaskComments_TaskID",
                table: "TaskComments",
                column: "TaskID");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskComments_TaskLists_TaskID",
                table: "TaskComments",
                column: "TaskID",
                principalTable: "TaskLists",
                principalColumn: "TaskID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskComments_TaskLists_TaskID",
                table: "TaskComments");

            migrationBuilder.DropIndex(
                name: "IX_TaskComments_TaskID",
                table: "TaskComments");
        }
    }
}
