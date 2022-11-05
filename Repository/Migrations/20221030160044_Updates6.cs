using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Updates6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumptions_UserDevices_UserDeviceId",
                table: "Consumptions");

            migrationBuilder.DropIndex(
                name: "IX_Consumptions_UserDeviceId",
                table: "Consumptions");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserDeviceId",
                table: "Consumptions",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserDevicesId",
                table: "Consumptions",
                nullable: true);

          
            migrationBuilder.CreateIndex(
                name: "IX_Consumptions_UserDevicesId",
                table: "Consumptions",
                column: "UserDevicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consumptions_UserDevices_UserDevicesId",
                table: "Consumptions",
                column: "UserDevicesId",
                principalTable: "UserDevices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumptions_UserDevices_UserDevicesId",
                table: "Consumptions");

            migrationBuilder.DropIndex(
                name: "IX_Consumptions_UserDevicesId",
                table: "Consumptions");

           
            migrationBuilder.DropColumn(
                name: "UserDevicesId",
                table: "Consumptions");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserDeviceId",
                table: "Consumptions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

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
    }
}
