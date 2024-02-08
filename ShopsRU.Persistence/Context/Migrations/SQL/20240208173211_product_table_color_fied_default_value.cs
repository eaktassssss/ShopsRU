using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopsRU.Persistence.Context.Migrations.SQL
{
    /// <inheritdoc />
    public partial class product_table_color_fied_default_value : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 612, DateTimeKind.Local).AddTicks(1662),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 922, DateTimeKind.Local).AddTicks(1233));

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Default Color",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 611, DateTimeKind.Local).AddTicks(3913),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 921, DateTimeKind.Local).AddTicks(4137));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 611, DateTimeKind.Local).AddTicks(7099),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 921, DateTimeKind.Local).AddTicks(7219));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 610, DateTimeKind.Local).AddTicks(9840),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 920, DateTimeKind.Local).AddTicks(9964));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 610, DateTimeKind.Local).AddTicks(5468),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 920, DateTimeKind.Local).AddTicks(5705));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "CustomerTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 610, DateTimeKind.Local).AddTicks(176),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 920, DateTimeKind.Local).AddTicks(394));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 609, DateTimeKind.Local).AddTicks(6764),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 919, DateTimeKind.Local).AddTicks(7091));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "CustomerDiscounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 609, DateTimeKind.Local).AddTicks(1671),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 919, DateTimeKind.Local).AddTicks(2272));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 612, DateTimeKind.Local).AddTicks(4795),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 922, DateTimeKind.Local).AddTicks(4176));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 32, 10, 612, DateTimeKind.Local).AddTicks(5535));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 32, 10, 612, DateTimeKind.Local).AddTicks(5542));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 32, 10, 612, DateTimeKind.Local).AddTicks(5543));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 32, 10, 612, DateTimeKind.Local).AddTicks(5544));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 32, 10, 610, DateTimeKind.Local).AddTicks(960));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 32, 10, 610, DateTimeKind.Local).AddTicks(965));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "JoiningDate" },
                values: new object[] { new DateTime(2024, 2, 8, 20, 32, 10, 609, DateTimeKind.Local).AddTicks(7638), new DateTime(2024, 2, 8, 20, 32, 10, 609, DateTimeKind.Local).AddTicks(7645) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "JoiningDate" },
                values: new object[] { new DateTime(2024, 2, 8, 20, 32, 10, 609, DateTimeKind.Local).AddTicks(7646), new DateTime(2024, 2, 8, 20, 32, 10, 609, DateTimeKind.Local).AddTicks(7647) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "JoiningDate" },
                values: new object[] { new DateTime(2024, 2, 8, 20, 32, 10, 609, DateTimeKind.Local).AddTicks(7648), new DateTime(2024, 2, 8, 20, 32, 10, 609, DateTimeKind.Local).AddTicks(7649) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "JoiningDate" },
                values: new object[] { new DateTime(2024, 2, 8, 20, 32, 10, 609, DateTimeKind.Local).AddTicks(7650), new DateTime(2024, 2, 8, 20, 32, 10, 609, DateTimeKind.Local).AddTicks(7651) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 32, 10, 610, DateTimeKind.Local).AddTicks(6207));

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 32, 10, 610, DateTimeKind.Local).AddTicks(6212));

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 32, 10, 610, DateTimeKind.Local).AddTicks(6213));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 32, 10, 612, DateTimeKind.Local).AddTicks(2508));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 32, 10, 612, DateTimeKind.Local).AddTicks(2514));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 32, 10, 612, DateTimeKind.Local).AddTicks(2515));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 32, 10, 612, DateTimeKind.Local).AddTicks(2517));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 922, DateTimeKind.Local).AddTicks(1233),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 612, DateTimeKind.Local).AddTicks(1662));

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Default Color");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 921, DateTimeKind.Local).AddTicks(4137),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 611, DateTimeKind.Local).AddTicks(3913));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 921, DateTimeKind.Local).AddTicks(7219),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 611, DateTimeKind.Local).AddTicks(7099));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 920, DateTimeKind.Local).AddTicks(9964),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 610, DateTimeKind.Local).AddTicks(9840));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 920, DateTimeKind.Local).AddTicks(5705),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 610, DateTimeKind.Local).AddTicks(5468));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "CustomerTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 920, DateTimeKind.Local).AddTicks(394),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 610, DateTimeKind.Local).AddTicks(176));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 919, DateTimeKind.Local).AddTicks(7091),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 609, DateTimeKind.Local).AddTicks(6764));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "CustomerDiscounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 919, DateTimeKind.Local).AddTicks(2272),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 609, DateTimeKind.Local).AddTicks(1671));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 922, DateTimeKind.Local).AddTicks(4176),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 612, DateTimeKind.Local).AddTicks(4795));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 11, 58, 922, DateTimeKind.Local).AddTicks(4919));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 11, 58, 922, DateTimeKind.Local).AddTicks(4926));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 11, 58, 922, DateTimeKind.Local).AddTicks(4928));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 11, 58, 922, DateTimeKind.Local).AddTicks(4929));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 11, 58, 920, DateTimeKind.Local).AddTicks(1184));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 11, 58, 920, DateTimeKind.Local).AddTicks(1193));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "JoiningDate" },
                values: new object[] { new DateTime(2024, 2, 8, 20, 11, 58, 919, DateTimeKind.Local).AddTicks(8007), new DateTime(2024, 2, 8, 20, 11, 58, 919, DateTimeKind.Local).AddTicks(8013) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "JoiningDate" },
                values: new object[] { new DateTime(2024, 2, 8, 20, 11, 58, 919, DateTimeKind.Local).AddTicks(8014), new DateTime(2024, 2, 8, 20, 11, 58, 919, DateTimeKind.Local).AddTicks(8015) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "JoiningDate" },
                values: new object[] { new DateTime(2024, 2, 8, 20, 11, 58, 919, DateTimeKind.Local).AddTicks(8016), new DateTime(2024, 2, 8, 20, 11, 58, 919, DateTimeKind.Local).AddTicks(8018) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "JoiningDate" },
                values: new object[] { new DateTime(2024, 2, 8, 20, 11, 58, 919, DateTimeKind.Local).AddTicks(8018), new DateTime(2024, 2, 8, 20, 11, 58, 919, DateTimeKind.Local).AddTicks(8020) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 11, 58, 920, DateTimeKind.Local).AddTicks(6466));

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 11, 58, 920, DateTimeKind.Local).AddTicks(6472));

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 11, 58, 920, DateTimeKind.Local).AddTicks(6473));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 11, 58, 922, DateTimeKind.Local).AddTicks(2079));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 11, 58, 922, DateTimeKind.Local).AddTicks(2086));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 11, 58, 922, DateTimeKind.Local).AddTicks(2088));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 11, 58, 922, DateTimeKind.Local).AddTicks(2090));
        }
    }
}
