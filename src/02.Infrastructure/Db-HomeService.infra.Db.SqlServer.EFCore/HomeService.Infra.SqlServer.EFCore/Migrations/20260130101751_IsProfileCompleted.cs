using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeService.Infra.SqlServer.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class IsProfileCompleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsProfileCompleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "240a37e0-3130-4e10-879e-b3763e854d78");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "21165d08-71b6-4cc6-ab43-5b2538c064ea");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "80a4f7f7-a6a2-4bf8-9ae5-6d954070d9cd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "IsProfileCompleted", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e608c3d9-b284-431a-ab60-e12babfe293b", true, "AQAAAAIAAYagAAAAEODm+1yAiyiK0nZ8S5ozBzY9VJxYlcKYMlLoGCIXYKy3+u91doz9jbXRUt0g5/gSxg==", "163d0322-f7f7-4ad0-963c-54bb3ffbf3fc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsProfileCompleted",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "6d359519-2de2-4963-9840-d14432a7da30");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "c03d66b4-05a5-489f-a023-15472a29a698");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "74e46a3e-35a4-4c35-9bea-b7aa5232611f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87699ec5-9c14-4f90-b8dd-4c5e54757971", "AQAAAAIAAYagAAAAEHqmsTohsOeQrr2REsI2TXNQ9uCt57U8u+fHONTrYktXeiprFi5rdcTAkXrOm5+MSw==", "72839029-35cd-48e0-86c4-a37a128d423d" });
        }
    }
}
