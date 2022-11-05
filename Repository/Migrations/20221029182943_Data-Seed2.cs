using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class DataSeed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fafcb5ea-e136-4f19-9673-a6a12193bf6b"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("e7e7f6ae-be57-4067-bb96-6f550513d64e"), 0, "179606e3-8df5-4926-8b49-3c4dd6c87b08", "adminApplication@gmail.com", true, null, null, false, null, "adminApplication@gmail.com", "Admin", "AQAAAAEAACcQAAAAEAiXRbRurkk2sgIlSZE6Pa+ZigK9t9XxN4FmTyPvbFR/1uy25CIydleJmJDM5ol6cQ==", null, false, 0, "04a965f6-8393-47fc-a080-ffd630c03112", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7e7f6ae-be57-4067-bb96-6f550513d64e"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("fafcb5ea-e136-4f19-9673-a6a12193bf6b"), 0, "252109de-b807-494a-b8fe-a7e749314ff8", "adminApplication@gmail.com", true, null, null, false, null, "adminApplication@gmail.com", "Admin", "AQAAAAEAACcQAAAAEJ2jU/5ABgrlddhssvEwgTc3SfC0iExBfHn6MvCltVs52zYuQjYcmQjr9oOCwtSnSA==", null, false, 0, "92f96586-8f80-4373-a69c-65a7655d9c99", false, "Admin" });
        }
    }
}
