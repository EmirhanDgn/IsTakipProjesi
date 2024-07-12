using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsTakipProjesi.Migrations
{
    /// <inheritdoc />
    public partial class TaskListeTaskMembereklemesi2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskMembers_TaskLists_TaskListTaskID",
                table: "TaskMembers");

            migrationBuilder.AlterColumn<int>(
                name: "TaskListTaskID",
                table: "TaskMembers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskMembers_TaskLists_TaskListTaskID",
                table: "TaskMembers",
                column: "TaskListTaskID",
                principalTable: "TaskLists",
                principalColumn: "TaskID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskMembers_TaskLists_TaskListTaskID",
                table: "TaskMembers");

            migrationBuilder.AlterColumn<int>(
                name: "TaskListTaskID",
                table: "TaskMembers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskMembers_TaskLists_TaskListTaskID",
                table: "TaskMembers",
                column: "TaskListTaskID",
                principalTable: "TaskLists",
                principalColumn: "TaskID");
        }
    }
}
