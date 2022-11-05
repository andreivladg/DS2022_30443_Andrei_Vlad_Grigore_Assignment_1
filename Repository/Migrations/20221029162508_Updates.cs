using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsumptionDate",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "kwh",
                table: "Devices");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeviceId",
                table: "Consumptions",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumptions_Devices_DeviceId",
                table: "Consumptions");

            migrationBuilder.DropIndex(
                name: "IX_Consumptions_DeviceId",
                table: "Consumptions");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "ConsumptionDate",
                table: "Devices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "kwh",
                table: "Devices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<Guid>(
                name: "DeviceId",
                table: "Consumptions",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
