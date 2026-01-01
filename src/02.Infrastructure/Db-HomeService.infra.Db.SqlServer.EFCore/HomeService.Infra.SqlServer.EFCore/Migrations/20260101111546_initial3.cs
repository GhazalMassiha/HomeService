using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeService.Infra.SqlServer.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpertSpecialities_Experts_ExpertId",
                table: "ExpertSpecialities");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpertSpecialities_Specialities_SpecialityId",
                table: "ExpertSpecialities");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ExpertSpecialities_Experts_ExpertId",
                table: "ExpertSpecialities",
                column: "ExpertId",
                principalTable: "Experts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpertSpecialities_Specialities_SpecialityId",
                table: "ExpertSpecialities",
                column: "SpecialityId",
                principalTable: "Specialities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpertSpecialities_Experts_ExpertId",
                table: "ExpertSpecialities");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpertSpecialities_Specialities_SpecialityId",
                table: "ExpertSpecialities");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "eb2f291a-8ca9-4521-858d-9fbfedc9b50a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "9f5f6bba-e744-4276-bf26-97416cf02006");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "8a76d1fe-d6d4-4110-95d0-9de5a4014741");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e67dea3-3e64-46d3-b87f-9ba4aa1391f4", "AQAAAAIAAYagAAAAEHXvYyrBY9P/fPKX+w4e2cq4vFhuxyzkAk5j+eF04rKn7hITa+GiTJIIMHnuf5KhRg==", "22f1508c-7018-4f54-8c3a-64467e7652db" });

            migrationBuilder.AddForeignKey(
                name: "FK_ExpertSpecialities_Experts_ExpertId",
                table: "ExpertSpecialities",
                column: "ExpertId",
                principalTable: "Experts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpertSpecialities_Specialities_SpecialityId",
                table: "ExpertSpecialities",
                column: "SpecialityId",
                principalTable: "Specialities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
