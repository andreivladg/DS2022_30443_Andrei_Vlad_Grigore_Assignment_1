using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class UpdateDevices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Address_AddressId",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_AspNetUsers_AppUserId",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Consumptions_ConsumptionId",
                table: "Devices");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Devices_AddressId",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_Devices_ConsumptionId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "ConsumptionId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Consumptions");

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "Devices",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Devices",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ConsumptionDate",
                table: "Devices",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Devices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Devices",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "kwh",
                table: "Devices",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "ConsumptionDate",
                table: "Consumptions",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_AspNetUsers_AppUserId",
                table: "Devices",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_AspNetUsers_AppUserId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "ConsumptionDate",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "kwh",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "ConsumptionDate",
                table: "Consumptions");

            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "Devices",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Devices",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConsumptionId",
                table: "Devices",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Consumptions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_AddressId",
                table: "Devices",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_ConsumptionId",
                table: "Devices",
                column: "ConsumptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Address_AddressId",
                table: "Devices",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_AspNetUsers_AppUserId",
                table: "Devices",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Consumptions_ConsumptionId",
                table: "Devices",
                column: "ConsumptionId",
                principalTable: "Consumptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
