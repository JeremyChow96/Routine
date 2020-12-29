using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Routine.API.Migrations
{
    public partial class addSeedItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("b1430e52-c5bc-47c2-8b5e-fadcaad8401c"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("cc43e36c-936b-4a59-8bb5-ec1b4c5b9604"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("fe91e907-95f6-4003-a25a-49f38406fd2d"));

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Introduction", "Name" },
                values: new object[,]
                {
                    { new Guid("bbdee09c-089b-4d30-bece-44df5923716c"), "Great Company", "Microsoft" },
                    { new Guid("bbdee09c-089b-4d30-bece-44df59237144"), "Not Exists?", "AOL" },
                    { new Guid("5efc910b-2f45-43df-afae-620d40542833"), "Store", "Amazon" },
                    { new Guid("6fb600c1-9011-4fd7-9234-881379716433"), "Music?", "NetEase" },
                    { new Guid("bbdee09c-089b-4d30-bece-44df59237133"), "Brothers", "Jingdong" },
                    { new Guid("5efc910b-2f45-43df-afae-620d40542822"), "- -", "360" },
                    { new Guid("6fb600c1-9011-4fd7-9234-881379716422"), "Blocked", "Youtube" },
                    { new Guid("bbdee09c-089b-4d30-bece-44df59237122"), "Blocked", "Twitter" },
                    { new Guid("5efc910b-2f45-43df-afae-620d40542811"), "From Jiangsu", "Suning" },
                    { new Guid("6fb600c1-9011-4fd7-9234-881379716411"), "Football Club", "AC Milan" },
                    { new Guid("bbdee09c-089b-4d30-bece-44df59237111"), "Wow", "SpaceX" },
                    { new Guid("5efc910b-2f45-43df-afae-620d40542800"), "Photoshop?", "Adobe" },
                    { new Guid("6fb600c1-9011-4fd7-9234-881379716400"), "From Beijing", "Baidu" },
                    { new Guid("bbdee09c-089b-4d30-bece-44df59237100"), "From Shenzhen", "Tencent" },
                    { new Guid("5efc910b-2f45-43df-afae-620d40542853"), "Fubao Company", "Alipapa" },
                    { new Guid("6fb600c1-9011-4fd7-9234-881379716440"), "Don't be evil", "Google" },
                    { new Guid("6fb600c1-9011-4fd7-9234-881379716444"), "Who?", "Yahoo" },
                    { new Guid("5efc910b-2f45-43df-afae-620d40542844"), "Is it a company?", "Firefox" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CompanyId", "DateOfBirth", "EmployeeNo", "FirstName", "Gender", "LastName" },
                values: new object[,]
                {
                    { new Guid("4b501cb3-d168-4cc0-b375-48fb33f318a4"), new Guid("bbdee09c-089b-4d30-bece-44df5923716c"), new DateTime(1976, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "MSFT231", "Nick", 1, "Carter" },
                    { new Guid("7eaa532c-1be5-472c-a738-94fd26e5fad6"), new Guid("bbdee09c-089b-4d30-bece-44df5923716c"), new DateTime(1981, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "MSFT245", "Vince", 1, "Carter" },
                    { new Guid("72457e73-ea34-4e02-b575-8d384e82a481"), new Guid("6fb600c1-9011-4fd7-9234-881379716440"), new DateTime(1986, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "G003", "Mary", 2, "King" },
                    { new Guid("7644b71d-d74e-43e2-ac32-8cbadd7b1c3a"), new Guid("6fb600c1-9011-4fd7-9234-881379716440"), new DateTime(1977, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "G097", "Kevin", 1, "Richardson" },
                    { new Guid("679dfd33-32e4-4393-b061-f7abb8956f53"), new Guid("5efc910b-2f45-43df-afae-620d40542853"), new DateTime(1967, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "A009", "卡", 2, "里" },
                    { new Guid("1861341e-b42b-410c-ae21-cf11f36fc574"), new Guid("5efc910b-2f45-43df-afae-620d40542853"), new DateTime(1957, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "A404", "Not", 1, "Man" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("5efc910b-2f45-43df-afae-620d40542800"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("5efc910b-2f45-43df-afae-620d40542811"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("5efc910b-2f45-43df-afae-620d40542822"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("5efc910b-2f45-43df-afae-620d40542833"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("5efc910b-2f45-43df-afae-620d40542844"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("6fb600c1-9011-4fd7-9234-881379716400"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("6fb600c1-9011-4fd7-9234-881379716411"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("6fb600c1-9011-4fd7-9234-881379716422"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("6fb600c1-9011-4fd7-9234-881379716433"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("6fb600c1-9011-4fd7-9234-881379716444"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("bbdee09c-089b-4d30-bece-44df59237100"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("bbdee09c-089b-4d30-bece-44df59237111"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("bbdee09c-089b-4d30-bece-44df59237122"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("bbdee09c-089b-4d30-bece-44df59237133"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("bbdee09c-089b-4d30-bece-44df59237144"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("1861341e-b42b-410c-ae21-cf11f36fc574"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("4b501cb3-d168-4cc0-b375-48fb33f318a4"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("679dfd33-32e4-4393-b061-f7abb8956f53"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("72457e73-ea34-4e02-b575-8d384e82a481"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("7644b71d-d74e-43e2-ac32-8cbadd7b1c3a"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("7eaa532c-1be5-472c-a738-94fd26e5fad6"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("5efc910b-2f45-43df-afae-620d40542853"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("6fb600c1-9011-4fd7-9234-881379716440"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: new Guid("bbdee09c-089b-4d30-bece-44df5923716c"));

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Introduction", "Name" },
                values: new object[] { new Guid("fe91e907-95f6-4003-a25a-49f38406fd2d"), "Great Company", "Micrsoft" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Introduction", "Name" },
                values: new object[] { new Guid("b1430e52-c5bc-47c2-8b5e-fadcaad8401c"), "Don't be evil", "Google" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Introduction", "Name" },
                values: new object[] { new Guid("cc43e36c-936b-4a59-8bb5-ec1b4c5b9604"), "Chinese Company", "Alipapa" });
        }
    }
}
