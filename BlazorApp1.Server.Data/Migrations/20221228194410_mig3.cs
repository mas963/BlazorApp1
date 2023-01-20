using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorApp1.Server.Data.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Suppliers",
                schema: "public",
                newName: "suppliers",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "public",
                newName: "orders",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "public",
                newName: "user",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                schema: "public",
                newName: "order_items",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "public",
                table: "suppliers",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "suppliers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "public",
                table: "orders",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "public",
                table: "orders",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "orders",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_supplier_id",
                schema: "public",
                table: "orders",
                newName: "IX_orders_supplier_id");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_created_user_id",
                schema: "public",
                table: "orders",
                newName: "IX_orders_created_user_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "user",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "public",
                table: "user",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "public",
                table: "user",
                newName: "first_name");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                schema: "public",
                table: "user",
                newName: "email_address");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "public",
                table: "order_items",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "public",
                table: "order_items",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_order_id",
                schema: "public",
                table: "order_items",
                newName: "IX_order_items_order_id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_created_user_id",
                schema: "public",
                table: "order_items",
                newName: "IX_order_items_created_user_id");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "public",
                table: "suppliers",
                type: "character varying",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                schema: "public",
                table: "suppliers",
                type: "uuid",
                nullable: false,
                defaultValueSql: "public.uuid_generate_v4()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                schema: "public",
                table: "orders",
                type: "character varying",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "public",
                table: "orders",
                type: "character varying",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                schema: "public",
                table: "orders",
                type: "uuid",
                nullable: false,
                defaultValueSql: "public.uuid_generate_v4()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                schema: "public",
                table: "user",
                type: "uuid",
                nullable: false,
                defaultValueSql: "public.uuid_generate_v4()",
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                schema: "public",
                table: "user",
                type: "character varying",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                schema: "public",
                table: "user",
                type: "character varying",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email_address",
                schema: "public",
                table: "user",
                type: "character varying",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "description",
                schema: "public",
                table: "order_items",
                type: "character varying",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                schema: "public",
                table: "order_items",
                type: "uuid",
                nullable: false,
                defaultValueSql: "public.uuid_generate_v4()",
                oldClrType: typeof(Guid),
                oldType: "uuid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "suppliers",
                schema: "public",
                newName: "Suppliers",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "orders",
                schema: "public",
                newName: "Orders",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "user",
                schema: "public",
                newName: "Users",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "order_items",
                schema: "public",
                newName: "OrderItems",
                newSchema: "public");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "public",
                table: "Suppliers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "Suppliers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "public",
                table: "Orders",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "public",
                table: "Orders",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_orders_supplier_id",
                schema: "public",
                table: "Orders",
                newName: "IX_Orders_supplier_id");

            migrationBuilder.RenameIndex(
                name: "IX_orders_created_user_id",
                schema: "public",
                table: "Orders",
                newName: "IX_Orders_created_user_id");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "last_name",
                schema: "public",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                schema: "public",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "email_address",
                schema: "public",
                table: "Users",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "description",
                schema: "public",
                table: "OrderItems",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "public",
                table: "OrderItems",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_order_items_order_id",
                schema: "public",
                table: "OrderItems",
                newName: "IX_OrderItems_order_id");

            migrationBuilder.RenameIndex(
                name: "IX_order_items_created_user_id",
                schema: "public",
                table: "OrderItems",
                newName: "IX_OrderItems_created_user_id");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "public",
                table: "Suppliers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "Suppliers",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "public.uuid_generate_v4()");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "public",
                table: "Orders",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "public",
                table: "Orders",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "Orders",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "public.uuid_generate_v4()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "Users",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "public.uuid_generate_v4()");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                schema: "public",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                schema: "public",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                schema: "public",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "public",
                table: "OrderItems",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                schema: "public",
                table: "OrderItems",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldDefaultValueSql: "public.uuid_generate_v4()");
        }
    }
}
