using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsTakipProjesi.Migrations
{
    /// <inheritdoc />
    public partial class TaskListeTaskMembereklemesi3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_TaskMembers_TaskID",
                table: "TaskMembers",
                column: "TaskID");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskMembers_TaskLists_TaskID",
                table: "TaskMembers",
                column: "TaskID",
                principalTable: "TaskLists",
                principalColumn: "TaskID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskMembers_TaskLists_TaskID",
                table: "TaskMembers");

            migrationBuilder.DropIndex(
                name: "IX_TaskMembers_TaskID",
                table: "TaskMembers");

            migrationBuilder.AddColumn<int>(
                name: "TaskListTaskID",
                table: "TaskMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TaskMembers_TaskListTaskID",
                table: "TaskMembers",
                column: "TaskListTaskID");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskMembers_TaskLists_TaskListTaskID",
                table: "TaskMembers",
                column: "TaskListTaskID",
                principalTable: "TaskLists",
                principalColumn: "TaskID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
