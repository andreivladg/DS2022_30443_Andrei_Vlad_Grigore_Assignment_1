using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class Updates8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Consumptions",
                columns: new[] { "Id", "ConsumptionDate", "UserDeviceId", "kwh" },
                values: new object[] { new Guid("b4d7a1f1-dd02-49eb-ad56-3bd0738a19dc"), new DateTime(2022, 10, 30, 16, 32, 4, 440, DateTimeKind.Utc).AddTicks(7505), new Guid("f72d3882-486f-454e-a18e-08daba6d8d8a"), 15});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DeleteData(
                table: "Consumptions",
                keyColumn: "Id",
                keyValue: new Guid("b4d7a1f1-dd02-49eb-ad56-3bd0738a19dc"));

        }
    }
}
