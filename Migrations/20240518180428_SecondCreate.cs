using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskMaster.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Fitness" },
                    { 4, "Hobbies" }
                });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2024, 5, 21, 13, 4, 28, 157, DateTimeKind.Local).AddTicks(286));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2024, 5, 19, 13, 4, 28, 157, DateTimeKind.Local).AddTicks(336));

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Description", "DueDate", "Priority", "Title", "UserId" },
                values: new object[,]
                {
                    { 5, "Prepare slides for Monday meeting", new DateTime(2024, 5, 23, 13, 4, 28, 157, DateTimeKind.Local).AddTicks(361), 1, "Prepare Presentation", 1 },
                    { 6, "Catch up with mom", new DateTime(2024, 5, 24, 13, 4, 28, 157, DateTimeKind.Local).AddTicks(369), 2, "Call Mom", 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[,]
                {
                    { 3, 9012, "AliceJohnson" },
                    { 4, 3456, "BobBrown" }
                });

            migrationBuilder.InsertData(
                table: "TaskCategories",
                columns: new[] { "Id", "CategoryId", "TaskId" },
                values: new object[,]
                {
                    { 5, 1, 5 },
                    { 6, 2, 6 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Description", "DueDate", "Priority", "Title", "UserId" },
                values: new object[,]
                {
                    { 3, "Workout session at the gym", new DateTime(2024, 5, 20, 13, 4, 28, 157, DateTimeKind.Local).AddTicks(345), 3, "Go to the Gym", 3 },
                    { 4, "Read 'The Great Gatsby'", new DateTime(2024, 5, 22, 13, 4, 28, 157, DateTimeKind.Local).AddTicks(353), 4, "Read Book", 4 }
                });

            migrationBuilder.InsertData(
                table: "TaskCategories",
                columns: new[] { "Id", "CategoryId", "TaskId" },
                values: new object[,]
                {
                    { 3, 3, 3 },
                    { 4, 4, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TaskCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "DueDate",
                value: new DateTime(2024, 5, 21, 12, 56, 4, 526, DateTimeKind.Local).AddTicks(4938));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "DueDate",
                value: new DateTime(2024, 5, 19, 12, 56, 4, 526, DateTimeKind.Local).AddTicks(5010));
        }
    }
}
