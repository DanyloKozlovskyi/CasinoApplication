using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Casino.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("074cdd40-be99-456d-9740-791abd93024f"), "bart@gmail.com", "Max", "Bart", "0987654321" },
                    { new Guid("1109a562-aa69-4d01-8eba-10175eeaad5c"), "bremer@gmail.com", "Mark", "Bremer", "1234567890" },
                    { new Guid("3ed704f4-40aa-42e2-8119-a6c6daaba0a6"), "thudor@gmail.com", "Richard", "Thudor", "1234567890" },
                    { new Guid("52fdf31c-27c4-498b-bad3-d56394b8d51d"), "john@gmail.com", "John", "Robinson", "1234567890" },
                    { new Guid("6d6b0494-edb0-439c-9fef-7d4bb5cb71f3"), "eugene@gmail.com", "Eugene", "Lagelle", "0987654321" },
                    { new Guid("74757949-c32b-44ea-a7d0-0bf457b8a90e"), "jackrich@gmail.com", "Jack", "Richardson", "0987654321" },
                    { new Guid("8558b449-4562-4234-a78f-2996681bff6a"), "rudhampspring@gmail.com", "Rudolf", "Hampspring", "1234567890" },
                    { new Guid("8fc92e40-f91f-40bf-89ff-5e68578d4367"), "joseph@gmail.com", "Joseph", "Borr", "1234567890" },
                    { new Guid("95da71d2-830b-4da6-8c35-55a96aa2487e"), "smithm@gmail.com", "Marry", "Smith", "0987654321" },
                    { new Guid("d46defd8-526b-4d86-b903-412f59673b2d"), "bluementhal@gmail.com", "George", "Bluementhal", "1234567890" },
                    { new Guid("d7e63a43-a93b-42ed-aa8f-727c75e53cda"), "bock@gmail.com", "Andrew", "Bock", "0987654321" },
                    { new Guid("df44d370-e174-4426-a52e-58a260f704eb"), "spencer@gmail.com", "Nicholas", "Spencer", "1234567890" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("074cdd40-be99-456d-9740-791abd93024f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1109a562-aa69-4d01-8eba-10175eeaad5c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3ed704f4-40aa-42e2-8119-a6c6daaba0a6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("52fdf31c-27c4-498b-bad3-d56394b8d51d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6d6b0494-edb0-439c-9fef-7d4bb5cb71f3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("74757949-c32b-44ea-a7d0-0bf457b8a90e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8558b449-4562-4234-a78f-2996681bff6a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8fc92e40-f91f-40bf-89ff-5e68578d4367"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("95da71d2-830b-4da6-8c35-55a96aa2487e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d46defd8-526b-4d86-b903-412f59673b2d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d7e63a43-a93b-42ed-aa8f-727c75e53cda"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("df44d370-e174-4426-a52e-58a260f704eb"));
        }
    }
}
