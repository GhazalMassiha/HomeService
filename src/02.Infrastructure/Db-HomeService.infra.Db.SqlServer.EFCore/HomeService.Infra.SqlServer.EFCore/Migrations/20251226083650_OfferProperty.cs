using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeService.Infra.SqlServer.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class OfferProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduledAt",
                table: "Offers",
                type: "datetime2",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScheduledAt",
                table: "Offers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "6e728874-4e86-442c-a964-82d9a54de833");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "11d9f16c-d256-4965-aa55-cac9a62569b0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "fe9d9b49-9791-4ece-967a-5327cc67c3c2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a819d70-95a6-4065-b82f-0d4c1bfd1586", "AQAAAAIAAYagAAAAECES4VvUlgRpMvdtovIIorqwHFQQADc6bzQILxbwiKJdb1PxL294y2sKOY6X5JtXJw==", "709ddaca-69cc-455f-ae28-8bd9613ab39e" });
        }
    }
}
