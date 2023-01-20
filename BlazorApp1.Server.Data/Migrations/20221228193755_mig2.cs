using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorApp1.Server.Data.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Users_CreatedUserId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Suppliers_SupplierId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_CreatedUserId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "Suppliers",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Orders",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "OrderItems",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "Users",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                schema: "public",
                table: "Users",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "public",
                table: "Suppliers",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                schema: "public",
                table: "Suppliers",
                newName: "createDate");

            migrationBuilder.RenameColumn(
                name: "WebURL",
                schema: "public",
                table: "Suppliers",
                newName: "web_url");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                schema: "public",
                table: "Orders",
                newName: "createdate");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                schema: "public",
                table: "Orders",
                newName: "supplier_id");

            migrationBuilder.RenameColumn(
                name: "ExpireDate",
                schema: "public",
                table: "Orders",
                newName: "expire_date");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId",
                schema: "public",
                table: "Orders",
                newName: "created_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_SupplierId",
                schema: "public",
                table: "Orders",
                newName: "IX_Orders_supplier_id");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CreatedUserId",
                schema: "public",
                table: "Orders",
                newName: "IX_Orders_created_user_id");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                schema: "public",
                table: "OrderItems",
                newName: "createdate");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                schema: "public",
                table: "OrderItems",
                newName: "order_id");

            migrationBuilder.RenameColumn(
                name: "CreatedUserId",
                schema: "public",
                table: "OrderItems",
                newName: "created_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderId",
                schema: "public",
                table: "OrderItems",
                newName: "IX_OrderItems_order_id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_CreatedUserId",
                schema: "public",
                table: "OrderItems",
                newName: "IX_OrderItems_created_user_id");

            migrationBuilder.AlterColumn<bool>(
                name: "isActive",
                schema: "public",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValueSql: "true",
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_date",
                schema: "public",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<bool>(
                name: "isActive",
                schema: "public",
                table: "Suppliers",
                type: "boolean",
                nullable: false,
                defaultValueSql: "true",
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<DateTime>(
                name: "createDate",
                schema: "public",
                table: "Suppliers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "web_url",
                schema: "public",
                table: "Suppliers",
                type: "character varying",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdate",
                schema: "public",
                table: "Orders",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "createdate",
                schema: "public",
                table: "OrderItems",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_id",
                schema: "public",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_supplier_id",
                schema: "public",
                table: "Suppliers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_order_id",
                schema: "public",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_orderItem_id",
                schema: "public",
                table: "OrderItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "fk_orderitems_order_id",
                schema: "public",
                table: "OrderItems",
                column: "order_id",
                principalSchema: "public",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_orderitems_user_id",
                schema: "public",
                table: "OrderItems",
                column: "created_user_id",
                principalSchema: "public",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_supplier_order_id",
                schema: "public",
                table: "Orders",
                column: "supplier_id",
                principalSchema: "public",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_order_id",
                schema: "public",
                table: "Orders",
                column: "created_user_id",
                principalSchema: "public",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_orderitems_order_id",
                schema: "public",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "fk_orderitems_user_id",
                schema: "public",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "fk_supplier_order_id",
                schema: "public",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "fk_user_order_id",
                schema: "public",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_id",
                schema: "public",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "pk_supplier_id",
                schema: "public",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "pk_order_id",
                schema: "public",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "pk_orderItem_id",
                schema: "public",
                table: "OrderItems");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "public",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                schema: "public",
                newName: "Suppliers");

            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "public",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                schema: "public",
                newName: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Users",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "create_date",
                table: "Users",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Suppliers",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "createDate",
                table: "Suppliers",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "web_url",
                table: "Suppliers",
                newName: "WebURL");

            migrationBuilder.RenameColumn(
                name: "createdate",
                table: "Orders",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "supplier_id",
                table: "Orders",
                newName: "SupplierId");

            migrationBuilder.RenameColumn(
                name: "expire_date",
                table: "Orders",
                newName: "ExpireDate");

            migrationBuilder.RenameColumn(
                name: "created_user_id",
                table: "Orders",
                newName: "CreatedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_supplier_id",
                table: "Orders",
                newName: "IX_Orders_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_created_user_id",
                table: "Orders",
                newName: "IX_Orders_CreatedUserId");

            migrationBuilder.RenameColumn(
                name: "createdate",
                table: "OrderItems",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "order_id",
                table: "OrderItems",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "created_user_id",
                table: "OrderItems",
                newName: "CreatedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_order_id",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_created_user_id",
                table: "OrderItems",
                newName: "IX_OrderItems_CreatedUserId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValueSql: "true");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Suppliers",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValueSql: "true");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Suppliers",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<string>(
                name: "WebURL",
                table: "Suppliers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Orders",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "OrderItems",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Users_CreatedUserId",
                table: "OrderItems",
                column: "CreatedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Suppliers_SupplierId",
                table: "Orders",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_CreatedUserId",
                table: "Orders",
                column: "CreatedUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
