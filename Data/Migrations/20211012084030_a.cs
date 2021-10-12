using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c5ec754-01b1-49cf-94e0-09250222b060",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c9b3d1aa-14fb-4d69-b8c9-cc1f07b29455", "40750a7c-3bbc-48b0-a4c3-0938cc0ba167" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3c5ec754-01b1-49cf-94e0-09250222b060",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "882a06da-c1f5-4dd3-add1-1fbf3691d87b", "ca4386e7-5e7a-476e-894c-079f925035c9" });
        }
    }
}
