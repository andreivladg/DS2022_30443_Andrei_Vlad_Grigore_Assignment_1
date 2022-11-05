using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Updates4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumptions_Devices_DeviceId",
                table: "Consumptions");

            migrationBuilder.DropIndex(
                name: "IX_Consumptions_DeviceId",
                table: "Consumptions");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("799624ed-e26d-4b0b-9ed1-e89a7dd9e045"));

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "Consumptions");

            migrationBuilder.AddColumn<Guid>(
                name: "UserDeviceId",
                table: "Consumptions",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("7bed19ce-b8c9-4e6f-a8d8-cb6c766abee8"), 0, "96622ce2-4410-4f30-aeb8-1eec69d5da7f", "adminApplication@gmail.com", true, null, null, false, null, "adminApplication@gmail.com", "Admin", "AQAAAAEAACcQAAAAEJQV1CJPAkqpAWKrO18ERVHmt31QmiEKebqGUOfrdHTifuWu6U5ef55AvcoCknv9sA==", null, false, 0, "4002c89f-3381-48f8-9078-ddcce79223e4", false, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Consumptions_UserDeviceId",
                table: "Consumptions",
                column: "UserDeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consumptions_UserDevices_UserDeviceId",
                table: "Consumptions",
                column: "UserDeviceId",
                principalTable: "UserDevices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumptions_UserDevices_UserDeviceId",
                table: "Consumptions");

            migrationBuilder.DropIndex(
                name: "IX_Consumptions_UserDeviceId",
                table: "Consumptions");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7bed19ce-b8c9-4e6f-a8d8-cb6c766abee8"));

            migrationBuilder.DropColumn(
                name: "UserDeviceId",
                table: "Consumptions");

            migrationBuilder.AddColumn<Guid>(
                name: "DeviceId",
                table: "Consumptions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("799624ed-e26d-4b0b-9ed1-e89a7dd9e045"), 0, "cca13bed-5d09-4729-bc33-c61a2db695e0", "adminApplication@gmail.com", true, null, null, false, null, "adminApplication@gmail.com", "Admin", "AQAAAAEAACcQAAAAENPR6Z2dg4yzYE6MjaVI3tWrMAlTW3052sNzSKh3vX5dv35n1PmhR7/RxnQC6g9tHA==", null, false, 0, "d55c00c8-4fdf-493f-8b23-bac28ed80250", false, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Consumptions_DeviceId",
                table: "Consumptions",
                column: "DeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consumptions_Devices_DeviceId",
                table: "Consumptions",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
