using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopsRU.Persistence.Context.Migrations.SQL
{
    /// <inheritdoc />
    public partial class product_table_color_fied_deleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 47, 39, 184, DateTimeKind.Local).AddTicks(716),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 612, DateTimeKind.Local).AddTicks(1662));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 47, 39, 183, DateTimeKind.Local).AddTicks(2245),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 611, DateTimeKind.Local).AddTicks(3913));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 47, 39, 183, DateTimeKind.Local).AddTicks(6213),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 611, DateTimeKind.Local).AddTicks(7099));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 47, 39, 182, DateTimeKind.Local).AddTicks(7045),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 610, DateTimeKind.Local).AddTicks(9840));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 47, 39, 182, DateTimeKind.Local).AddTicks(2068),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 610, DateTimeKind.Local).AddTicks(5468));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "CustomerTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 47, 39, 181, DateTimeKind.Local).AddTicks(6526),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 610, DateTimeKind.Local).AddTicks(176));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 47, 39, 181, DateTimeKind.Local).AddTicks(3018),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 609, DateTimeKind.Local).AddTicks(6764));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "CustomerDiscounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 47, 39, 180, DateTimeKind.Local).AddTicks(7742),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 609, DateTimeKind.Local).AddTicks(1671));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 47, 39, 184, DateTimeKind.Local).AddTicks(3849),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 612, DateTimeKind.Local).AddTicks(4795));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 47, 39, 184, DateTimeKind.Local).AddTicks(4580));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 47, 39, 184, DateTimeKind.Local).AddTicks(4585));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 47, 39, 184, DateTimeKind.Local).AddTicks(4587));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 47, 39, 184, DateTimeKind.Local).AddTicks(4588));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 47, 39, 181, DateTimeKind.Local).AddTicks(7279));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 47, 39, 181, DateTimeKind.Local).AddTicks(7285));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "JoiningDate" },
                values: new object[] { new DateTime(2024, 2, 8, 20, 47, 39, 181, DateTimeKind.Local).AddTicks(3897), new DateTime(2024, 2, 8, 20, 47, 39, 181, DateTimeKind.Local).AddTicks(3901) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "JoiningDate" },
                values: new object[] { new DateTime(2024, 2, 8, 20, 47, 39, 181, DateTimeKind.Local).AddTicks(3902), new DateTime(2024, 2, 8, 20, 47, 39, 181, DateTimeKind.Local).AddTicks(3903) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "JoiningDate" },
                values: new object[] { new DateTime(2024, 2, 8, 20, 47, 39, 181, DateTimeKind.Local).AddTicks(3904), new DateTime(2024, 2, 8, 20, 47, 39, 181, DateTimeKind.Local).AddTicks(3905) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "JoiningDate" },
                values: new object[] { new DateTime(2024, 2, 8, 20, 47, 39, 181, DateTimeKind.Local).AddTicks(3906), new DateTime(2024, 2, 8, 20, 47, 39, 181, DateTimeKind.Local).AddTicks(3907) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 47, 39, 182, DateTimeKind.Local).AddTicks(2827));

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 47, 39, 182, DateTimeKind.Local).AddTicks(2832));

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 47, 39, 182, DateTimeKind.Local).AddTicks(2833));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 47, 39, 184, DateTimeKind.Local).AddTicks(1591));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 47, 39, 184, DateTimeKind.Local).AddTicks(1596));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 47, 39, 184, DateTimeKind.Local).AddTicks(1598));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 20, 47, 39, 184, DateTimeKind.Local).AddTicks(1599));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 612, DateTimeKind.Local).AddTicks(1662),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 47, 39, 184, DateTimeKind.Local).AddTicks(716));

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Default Color");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 611, DateTimeKind.Local).AddTicks(3913),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 47, 39, 183, DateTimeKind.Local).AddTicks(2245));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 611, DateTimeKind.Local).AddTicks(7099),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 47, 39, 183, DateTimeKind.Local).AddTicks(6213));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 610, DateTimeKind.Local).AddTicks(9840),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 47, 39, 182, DateTimeKind.Local).AddTicks(7045));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 610, DateTimeKind.Local).AddTicks(5468),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 47, 39, 182, DateTimeKind.Local).AddTicks(2068));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "CustomerTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 610, DateTimeKind.Local).AddTicks(176),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 47, 39, 181, DateTimeKind.Local).AddTicks(6526));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 609, DateTimeKind.Local).AddTicks(6764),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 47, 39, 181, DateTimeKind.Local).AddTicks(3018));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "CustomerDiscounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 609, DateTimeKind.Local).AddTicks(1671),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 47, 39, 180, DateTimeKind.Local).AddTicks(7742));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 32, 10, 612, DateTimeKind.Local).AddTicks(4795),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 47, 39, 184, DateTimeKind.Local).AddTicks(3849));

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
                columns: new[] { "Color", "CreatedOn" },
                values: new object[] { "Red", new DateTime(2024, 2, 8, 20, 32, 10, 612, DateTimeKind.Local).AddTicks(2508) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "CreatedOn" },
                values: new object[] { "Yellow", new DateTime(2024, 2, 8, 20, 32, 10, 612, DateTimeKind.Local).AddTicks(2514) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Color", "CreatedOn" },
                values: new object[] { "White", new DateTime(2024, 2, 8, 20, 32, 10, 612, DateTimeKind.Local).AddTicks(2515) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Color", "CreatedOn" },
                values: new object[] { "Blue", new DateTime(2024, 2, 8, 20, 32, 10, 612, DateTimeKind.Local).AddTicks(2517) });
        }
    }
}
