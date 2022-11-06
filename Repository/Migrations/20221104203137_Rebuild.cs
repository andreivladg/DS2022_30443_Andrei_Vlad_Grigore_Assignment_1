using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Rebuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

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

            migrationBuilder.InsertData(
                table: "Consumptions",
                columns: new[] { "Id", "ConsumptionDate", "UserDeviceId", "kwh" },
                values: new object[] { new Guid("b4d7a1f1-dd02-49eb-ad56-3bd0738a19dc"), new DateTime(2022, 10, 30, 16, 32, 4, 440, DateTimeKind.Utc).AddTicks(7505), new Guid("f72d3882-486f-454e-a18e-08daba6d8d8a"), -79228162514264337593543950335m });
           
      
        }
    }
}
