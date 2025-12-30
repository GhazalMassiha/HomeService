using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeService.Infra.SqlServer.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class fixingRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e81e109c-3caf-4688-8e8b-b913f3eeb51a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "baca6dfc-b871-47ac-bb9a-ed6e8a6d31bf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "244a9e04-0079-4ef9-b5d5-036096d42e62");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08938fec-93d9-4ccd-b953-ff623c53bc0b", "AQAAAAIAAYagAAAAEFUkefOxqAkMQIozQFjfPsz0YJpW4yQa0fq0l78f9SfHe5yD9P17aHj4Th3BMREg9A==", "b15e6c14-0081-499b-9d84-7c557eb94c8d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "9c14c07a-5647-493e-8ceb-c823a17814a3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "aba5fede-f9d6-43f8-b396-f6e52e75be9c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "e2ff7b38-d42e-4f05-944c-234d0f3375ce");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21dc6e96-0b2a-418a-8dda-bd8687972f03", "AQAAAAIAAYagAAAAEHsDKNVSss9CQyP19hv+d1xXFOYcNfPpkmjS8vw0eUSmaf4iugoroK7Hg/qY1oIIJQ==", "1584eced-f344-4a08-b270-5ced74cdb8b3" });
        }
    }
}
