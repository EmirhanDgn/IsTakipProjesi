using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsTakipProjesi.Migrations
{
    /// <inheritdoc />
    public partial class migg3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "TaskComments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_TaskComments_UserID",
                table: "TaskComments",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskComments_Users_UserID",
                table: "TaskComments",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskComments_Users_UserID",
                table: "TaskComments");

            migrationBuilder.DropIndex(
                name: "IX_TaskComments_UserID",
                table: "TaskComments");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "TaskComments",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
