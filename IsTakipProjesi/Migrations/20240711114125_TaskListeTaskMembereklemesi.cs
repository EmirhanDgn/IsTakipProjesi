using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsTakipProjesi.Migrations
{
    /// <inheritdoc />
    public partial class TaskListeTaskMembereklemesi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskListTaskID",
                table: "TaskMembers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskMembers_TaskListTaskID",
                table: "TaskMembers",
                column: "TaskListTaskID");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskMembers_TaskLists_TaskListTaskID",
                table: "TaskMembers",
                column: "TaskListTaskID",
                principalTable: "TaskLists",
                principalColumn: "TaskID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskMembers_TaskLists_TaskListTaskID",
                table: "TaskMembers");

            migrationBuilder.DropIndex(
                name: "IX_TaskMembers_TaskListTaskID",
                table: "TaskMembers");

            migrationBuilder.DropColumn(
                name: "TaskListTaskID",
                table: "TaskMembers");
        }
    }
}
