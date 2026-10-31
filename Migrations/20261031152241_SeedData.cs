using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hihi.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Login", "Password", "Role" },
                values: new object[] { "master07", "12345", "Пользователь" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Login", "Password", "Role" },
                values: new object[] { "admin", "admin", "Администратор" });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "CreatedAt", "Title" },
                values: new object[] { "iPhone 12", new DateTime(2027, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Замена экрана" });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Content", "CreatedAt", "IdClient", "Title" },
                values: new object[] { "Lenovo", new DateTime(2027, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Чистка ноутбука" });

            migrationBuilder.InsertData(
                table: "Requests",
                columns: new[] { "Id", "Content", "CreatedAt", "IdClient", "Title" },
                values: new object[] { 3, "Windows 11", new DateTime(2027, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Установка ПО" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Login", "Password", "Role" },
                values: new object[] { "ivanov", "123", "User" });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Login", "Password", "Role" },
                values: new object[] { "petrov", "456", "Admin" });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "CreatedAt", "Title" },
                values: new object[] { "Помогите", new DateTime(2023, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Не работает принтер" });

            migrationBuilder.UpdateData(
                table: "Requests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Content", "CreatedAt", "IdClient", "Title" },
                values: new object[] { "Нужен доступ", new DateTime(2023, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Доступ к папке" });
        }
    }
}
