using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopsRU.Persistence.Context.Migrations.SQL
{
    /// <inheritdoc />
    public partial class product_table_color_fied_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 922, DateTimeKind.Local).AddTicks(1233),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 17, 22, 4, 341, DateTimeKind.Local).AddTicks(9675));

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 921, DateTimeKind.Local).AddTicks(4137),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 17, 22, 4, 341, DateTimeKind.Local).AddTicks(2841));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 921, DateTimeKind.Local).AddTicks(7219),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 17, 22, 4, 341, DateTimeKind.Local).AddTicks(5890));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 920, DateTimeKind.Local).AddTicks(9964),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 17, 22, 4, 340, DateTimeKind.Local).AddTicks(8570));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 920, DateTimeKind.Local).AddTicks(5705),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 17, 22, 4, 340, DateTimeKind.Local).AddTicks(4052));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "CustomerTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 920, DateTimeKind.Local).AddTicks(394),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 17, 22, 4, 339, DateTimeKind.Local).AddTicks(8241));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 919, DateTimeKind.Local).AddTicks(7091),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 17, 22, 4, 339, DateTimeKind.Local).AddTicks(4316));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "CustomerDiscounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 919, DateTimeKind.Local).AddTicks(2272),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 17, 22, 4, 338, DateTimeKind.Local).AddTicks(8419));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 922, DateTimeKind.Local).AddTicks(4176),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 17, 22, 4, 342, DateTimeKind.Local).AddTicks(2658));

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
                columns: new[] { "Color", "CreatedOn" },
                values: new object[] { "Red", new DateTime(2024, 2, 8, 20, 11, 58, 922, DateTimeKind.Local).AddTicks(2079) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "CreatedOn" },
                values: new object[] { "Yellow", new DateTime(2024, 2, 8, 20, 11, 58, 922, DateTimeKind.Local).AddTicks(2086) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Color", "CreatedOn" },
                values: new object[] { "White", new DateTime(2024, 2, 8, 20, 11, 58, 922, DateTimeKind.Local).AddTicks(2088) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Color", "CreatedOn" },
                values: new object[] { "Blue", new DateTime(2024, 2, 8, 20, 11, 58, 922, DateTimeKind.Local).AddTicks(2090) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 17, 22, 4, 341, DateTimeKind.Local).AddTicks(9675),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 922, DateTimeKind.Local).AddTicks(1233));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 17, 22, 4, 341, DateTimeKind.Local).AddTicks(2841),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 921, DateTimeKind.Local).AddTicks(4137));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 17, 22, 4, 341, DateTimeKind.Local).AddTicks(5890),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 921, DateTimeKind.Local).AddTicks(7219));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 17, 22, 4, 340, DateTimeKind.Local).AddTicks(8570),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 920, DateTimeKind.Local).AddTicks(9964));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 17, 22, 4, 340, DateTimeKind.Local).AddTicks(4052),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 920, DateTimeKind.Local).AddTicks(5705));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "CustomerTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 17, 22, 4, 339, DateTimeKind.Local).AddTicks(8241),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 920, DateTimeKind.Local).AddTicks(394));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 17, 22, 4, 339, DateTimeKind.Local).AddTicks(4316),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 919, DateTimeKind.Local).AddTicks(7091));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "CustomerDiscounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 17, 22, 4, 338, DateTimeKind.Local).AddTicks(8419),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 919, DateTimeKind.Local).AddTicks(2272));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 8, 17, 22, 4, 342, DateTimeKind.Local).AddTicks(2658),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 8, 20, 11, 58, 922, DateTimeKind.Local).AddTicks(4176));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 17, 22, 4, 342, DateTimeKind.Local).AddTicks(3406));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 17, 22, 4, 342, DateTimeKind.Local).AddTicks(3412));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 17, 22, 4, 342, DateTimeKind.Local).AddTicks(3414));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 17, 22, 4, 342, DateTimeKind.Local).AddTicks(3415));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 17, 22, 4, 339, DateTimeKind.Local).AddTicks(9051));

            migrationBuilder.UpdateData(
                table: "CustomerTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 17, 22, 4, 339, DateTimeKind.Local).AddTicks(9058));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "JoiningDate" },
                values: new object[] { new DateTime(2024, 2, 8, 17, 22, 4, 339, DateTimeKind.Local).AddTicks(5226), new DateTime(2024, 2, 8, 17, 22, 4, 339, DateTimeKind.Local).AddTicks(5233) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "JoiningDate" },
                values: new object[] { new DateTime(2024, 2, 8, 17, 22, 4, 339, DateTimeKind.Local).AddTicks(5234), new DateTime(2024, 2, 8, 17, 22, 4, 339, DateTimeKind.Local).AddTicks(5235) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "JoiningDate" },
                values: new object[] { new DateTime(2024, 2, 8, 17, 22, 4, 339, DateTimeKind.Local).AddTicks(5236), new DateTime(2024, 2, 8, 17, 22, 4, 339, DateTimeKind.Local).AddTicks(5237) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "JoiningDate" },
                values: new object[] { new DateTime(2024, 2, 8, 17, 22, 4, 339, DateTimeKind.Local).AddTicks(5238), new DateTime(2024, 2, 8, 17, 22, 4, 339, DateTimeKind.Local).AddTicks(5239) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 17, 22, 4, 340, DateTimeKind.Local).AddTicks(4825));

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 17, 22, 4, 340, DateTimeKind.Local).AddTicks(4830));

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 17, 22, 4, 340, DateTimeKind.Local).AddTicks(4832));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 17, 22, 4, 342, DateTimeKind.Local).AddTicks(542));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 17, 22, 4, 342, DateTimeKind.Local).AddTicks(547));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 17, 22, 4, 342, DateTimeKind.Local).AddTicks(549));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 2, 8, 17, 22, 4, 342, DateTimeKind.Local).AddTicks(550));
        }
    }
}
