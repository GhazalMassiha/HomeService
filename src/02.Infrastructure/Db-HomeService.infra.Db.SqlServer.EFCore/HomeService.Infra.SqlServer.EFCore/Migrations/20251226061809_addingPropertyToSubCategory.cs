using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeService.Infra.SqlServer.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class addingPropertyToSubCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BasePrice",
                table: "SubCategories",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SubCategories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BasePrice", "Description" },
                values: new object[] { 500000m, "انجام عملیات بنایی و ساخت دیوار، آجرکاری و تسطیح سطوح" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BasePrice", "Description" },
                values: new object[] { 700000m, "طراحی و اجرای دکوراسیون داخلی، نصب دیوارپوش و عناصر تزئینی" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BasePrice", "Description" },
                values: new object[] { 400000m, "رنگ‌آمیزی سطوح داخلی و خارجی با رنگ‌های باکیفیت" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BasePrice", "Description" },
                values: new object[] { 600000m, "نصب و تعمیر انواع درب و پنجره با دقت و آب‌بندی مناسب" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BasePrice", "Description" },
                values: new object[] { 800000m, "انجام کارهای فلزی، جوشکاری و ساخت نرده و حفاظ" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BasePrice", "Description" },
                values: new object[] { 300000m, "طراحی و نگهداری فضای سبز و چمن‌کاری" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BasePrice", "Description" },
                values: new object[] { 900000m, "نصب و سرویس سیستم‌های کولر و بخاری" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BasePrice", "Description" },
                values: new object[] { 650000m, "نصب و تعمیر لوله‌های آب و فاضلاب" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BasePrice", "Description" },
                values: new object[] { 550000m, "خدمات برق‌کشی و نصب تجهیزات الکتریکی" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BasePrice", "Description" },
                values: new object[] { 750000m, "نصب و راه‌اندازی سیستم‌های تلفن و سانترال" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "BasePrice", "Description" },
                values: new object[] { 1000000m, "تعمیر و سرویس خودروهای سبک و سنگین" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "BasePrice", "Description" },
                values: new object[] { 1200000m, "حمل ایمن اسباب و بسته‌بندی وسایل" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "BasePrice", "Description" },
                values: new object[] { 800000m, "حمل بار شهری با تجهیزات مناسب" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "BasePrice", "Description" },
                values: new object[] { 600000m, "نصب و تعمیر لوازم آشپزخانه" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "BasePrice", "Description" },
                values: new object[] { 550000m, "تعمیر تجهیزات شستشو و نظافتی" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "BasePrice", "Description" },
                values: new object[] { 650000m, "نصب و تعمیر سیستم‌های صوتی و تصویری" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "BasePrice", "Description" },
                values: new object[] { 700000m, "خدمات تعمیر و نگهداری ماشین‌های اداری" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "BasePrice", "Description" },
                values: new object[] { 900000m, "نصب و تعمیر مبلمان و تجهیزات اداری" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "BasePrice", "Description" },
                values: new object[] { 400000m, "نظافت حرفه‌ای منزل و محل کار" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "BasePrice", "Description" },
                values: new object[] { 500000m, "شستشوی حرفه‌ای فرش و مبلمان" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "BasePrice", "Description" },
                values: new object[] { 600000m, "شستشو و پاکسازی فرش و مبل تهیه‌شده" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "BasePrice", "Description" },
                values: new object[] { 450000m, "سمپاشی حرفه‌ای برای دفع آفات" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "BasePrice", "Description" },
                values: new object[] { 700000m, "تعمیر موبایل و تبلت با قطعات استاندارد" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "BasePrice", "Description" },
                values: new object[] { 650000m, "نصب و راه‌اندازی کامپیوتر و شبکه" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "BasePrice", "Description" },
                values: new object[] { 1200000m, "پیاده‌سازی و پشتیبانی شبکه و امنیت" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "BasePrice", "Description" },
                values: new object[] { 1500000m, "خدمات پزشکی اولیه در محل" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BasePrice",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "SubCategories");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "8d37a83b-3493-4c01-8e40-4cd6972b5bc3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "800e9451-9a34-4ab5-b9e8-f653f0011c34");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "01202993-54a5-47c4-b3f2-8a9e8f39b421");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c12df6f-6553-4b19-b468-e2a93053ab31", "AQAAAAIAAYagAAAAEGUZfLjCjXDeEepU9KWEsSW+H6NKQOHirte/GMeTNWr6ImjKkv/TzzgwWbmW9XtH2g==", "d976c6b3-ba64-426b-b1cd-3efd21dfe232" });
        }
    }
}
