using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Rebuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumptions_UserDevices_UserDeviceId",
                table: "Consumptions");

            migrationBuilder.DropTable(
                name: "UserDevices");

            migrationBuilder.DropIndex(
                name: "IX_Consumptions_UserDeviceId",
                table: "Consumptions");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("73fdb331-29f4-40a8-99f1-0f72fec7f6cc"));

            migrationBuilder.DeleteData(
                table: "Consumptions",
                keyColumn: "Id",
                keyValue: new Guid("b4d7a1f1-dd02-49eb-ad56-3bd0738a19dc"));

            migrationBuilder.DropColumn(
                name: "UserDeviceId",
                table: "Consumptions");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Devices",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DeviceId",
                table: "Consumptions",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("7fd40f35-3643-4743-abd0-bfa7b4509ff9"), 0, "1cebfaf3-4463-4217-8afc-ab22e78335db", "adminApplication@gmail.com", true, null, null, false, null, "adminApplication@gmail.com", "Admin", "AQAAAAEAACcQAAAAEKRYMPuY6mp+YU/KC8dopMxD95NUXQv5uET5w/MWoro3JAoCgUzN7hVDUPRgTMOYnA==", null, false, 0, "efa7222c-79e0-48d8-9984-88e3eb45ca2d", false, "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_UserId",
                table: "Devices",
                column: "UserId");

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
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_AspNetUsers_UserId",
                table: "Devices",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumptions_Devices_DeviceId",
                table: "Consumptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_AspNetUsers_UserId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_UserId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Consumptions_DeviceId",
                table: "Consumptions");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7fd40f35-3643-4743-abd0-bfa7b4509ff9"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "Consumptions");

            migrationBuilder.AddColumn<Guid>(
                name: "UserDeviceId",
                table: "Consumptions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "UserDevices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDevices_Devices_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDevices_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("73fdb331-29f4-40a8-99f1-0f72fec7f6cc"), 0, "a436165d-7294-46b7-a2ff-7d9b8a2c95a5", "adminApplication@gmail.com", true, null, null, false, null, "adminApplication@gmail.com", "Admin", "AQAAAAEAACcQAAAAEDkVl6R2RnK4ILG7kavB9cG4OErd2FyrwURvGPUN0KkZd5HuD4Jt+P+ezK0q0BVTYA==", null, false, 0, "70f45de6-265f-4e01-abf1-e240bac39ffa", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Consumptions",
                columns: new[] { "Id", "ConsumptionDate", "UserDeviceId", "kwh" },
                values: new object[] { new Guid("b4d7a1f1-dd02-49eb-ad56-3bd0738a19dc"), new DateTime(2022, 10, 30, 16, 32, 4, 440, DateTimeKind.Utc).AddTicks(7505), new Guid("f72d3882-486f-454e-a18e-08daba6d8d8a"), -79228162514264337593543950335m });

            migrationBuilder.CreateIndex(
                name: "IX_Consumptions_UserDeviceId",
                table: "Consumptions",
                column: "UserDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDevices_DeviceId",
                table: "UserDevices",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDevices_UserId",
                table: "UserDevices",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consumptions_UserDevices_UserDeviceId",
                table: "Consumptions",
                column: "UserDeviceId",
                principalTable: "UserDevices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
