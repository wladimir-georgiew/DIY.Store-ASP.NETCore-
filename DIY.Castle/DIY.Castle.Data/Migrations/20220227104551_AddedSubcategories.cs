using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DIY.Castle.Data.Migrations
{
    public partial class AddedSubcategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubcategoryId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Subcategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategory", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "f648ad53-dbaf-43a8-8205-c22e63352246");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a360047c-cd04-403f-b10c-7a97e480368c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000AFADMIN000",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9813e2b8-8da5-43e3-aa3c-9115219a5468", "AQAAAAEAACcQAAAAEAYP83xgJ+T8CL94NfGu209BIDlFqP9AAVkoiS11d0RvmIf6DVkepTLj18DVCTAuqw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubcategoryId",
                table: "Products",
                column: "SubcategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Subcategory_SubcategoryId",
                table: "Products",
                column: "SubcategoryId",
                principalTable: "Subcategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Subcategory_SubcategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Subcategory");

            migrationBuilder.DropIndex(
                name: "IX_Products_SubcategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SubcategoryId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0",
                column: "ConcurrencyStamp",
                value: "3f27661a-f737-4ff7-9095-e32ac56ded95");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "2ab4a043-eecd-4a31-8e94-904311ec2140");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "000AFADMIN000",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "08ed0e19-e2b9-4d82-af61-d1a1826f437a", "AQAAAAEAACcQAAAAEM1hTmLORUDijixMXB5vuwzdG4FJLhXixaQmjd+zoIzaW/CWG8qMjKL4CCfGOGis9A==" });
        }
    }
}
