using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EtkinlikAPI.Migrations
{
    /// <inheritdoc />
    public partial class CategoryTableIconNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "AddDate", "DeleteDate", "Icon", "IsDeleted", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("2d2f6f35-c642-4e2f-a97a-d53522663c40"), new DateTime(2024, 6, 2, 11, 21, 32, 904, DateTimeKind.Local).AddTicks(8772), null, null, false, "Eğlence", null },
                    { new Guid("511018ca-7efe-4e78-8de2-b299b687ce62"), new DateTime(2024, 6, 2, 11, 21, 32, 904, DateTimeKind.Local).AddTicks(8721), null, null, false, "Sağlık", null },
                    { new Guid("5a163cbc-dc3d-432f-8e4f-dbf0e2c7fbdc"), new DateTime(2024, 6, 2, 11, 21, 32, 904, DateTimeKind.Local).AddTicks(8744), null, null, false, "Sanat", null },
                    { new Guid("60024570-ff17-4044-bef5-d9c37614418d"), new DateTime(2024, 6, 2, 11, 21, 32, 904, DateTimeKind.Local).AddTicks(8699), null, null, false, "Teknoloji", null },
                    { new Guid("69054b03-687c-45ad-a1f5-fb8d32d7fefe"), new DateTime(2024, 6, 2, 11, 21, 32, 904, DateTimeKind.Local).AddTicks(8666), null, null, false, "Yazılım", null },
                    { new Guid("6e1b7942-86b1-4180-8d34-3ae1d9fff2d0"), new DateTime(2024, 6, 2, 11, 21, 32, 904, DateTimeKind.Local).AddTicks(8710), null, null, false, "Eğitim", null },
                    { new Guid("baaa54dc-5d52-419a-898f-a0aac633138a"), new DateTime(2024, 6, 2, 11, 21, 32, 904, DateTimeKind.Local).AddTicks(8783), null, null, false, "Diğer", null },
                    { new Guid("d78b8bad-0aeb-4a2b-8299-ec89088248c6"), new DateTime(2024, 6, 2, 11, 21, 32, 904, DateTimeKind.Local).AddTicks(8754), null, null, false, "Müzik", null },
                    { new Guid("e4dd4dcc-f116-4f95-b5ab-4ad5c9f4df11"), new DateTime(2024, 6, 2, 11, 21, 32, 904, DateTimeKind.Local).AddTicks(8732), null, null, false, "Spor", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2d2f6f35-c642-4e2f-a97a-d53522663c40"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("511018ca-7efe-4e78-8de2-b299b687ce62"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5a163cbc-dc3d-432f-8e4f-dbf0e2c7fbdc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("60024570-ff17-4044-bef5-d9c37614418d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("69054b03-687c-45ad-a1f5-fb8d32d7fefe"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6e1b7942-86b1-4180-8d34-3ae1d9fff2d0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("baaa54dc-5d52-419a-898f-a0aac633138a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d78b8bad-0aeb-4a2b-8299-ec89088248c6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e4dd4dcc-f116-4f95-b5ab-4ad5c9f4df11"));

            migrationBuilder.AlterColumn<string>(
                name: "Icon",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
