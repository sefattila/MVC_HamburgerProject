using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HamburgerProject.REPOSITORY.Migrations
{
    public partial class appUserModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8210eea6-4616-4dd6-9939-275a82de8d1b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94171a81-50cc-4768-8392-d7cac5e40a33");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "00afb5c7-20bf-4941-a649-c4b8622fcea6", "08bc974a-4486-46c3-a873-6cc441319ee9", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3f1e6736-ebaf-4abc-bdc5-f14a8bd898b6", "d107251f-5375-47bc-ad1b-4893e6320f7b", "user", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00afb5c7-20bf-4941-a649-c4b8622fcea6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f1e6736-ebaf-4abc-bdc5-f14a8bd898b6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8210eea6-4616-4dd6-9939-275a82de8d1b", "b4296043-6167-40e2-a8ff-4198632a7453", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "94171a81-50cc-4768-8392-d7cac5e40a33", "a28b7ff4-65a8-457d-89b6-7847bae91686", "admin", "ADMIN" });
        }
    }
}
