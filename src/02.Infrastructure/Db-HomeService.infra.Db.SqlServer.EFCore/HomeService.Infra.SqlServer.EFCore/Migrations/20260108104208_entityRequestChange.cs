using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeService.Infra.SqlServer.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class entityRequestChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpecialityId",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Requests_CategoryId",
                table: "Requests",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_SpecialityId",
                table: "Requests",
                column: "SpecialityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Categories_CategoryId",
                table: "Requests",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Specialities_SpecialityId",
                table: "Requests",
                column: "SpecialityId",
                principalTable: "Specialities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Categories_CategoryId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Specialities_SpecialityId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_CategoryId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_SpecialityId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "SpecialityId",
                table: "Requests");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "313b604f-8bb9-41b4-ba63-f7f802900682");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "9a046fd0-b196-438b-af6f-20af34190b78");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "0cbe8d4d-2152-40b3-8cf1-30fd5859d34d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f3aaf3f-c599-4dad-a5e8-ef0c10c1cbd9", "AQAAAAIAAYagAAAAECX9eVhUogduNpuRuSGeCs8oogEsr550ThPUFsr4gX7Ok+3prDdxUNYoURk/g8OEAQ==", "dd536e8f-85fe-47b9-85fd-4982117f09ce" });
        }
    }
}
