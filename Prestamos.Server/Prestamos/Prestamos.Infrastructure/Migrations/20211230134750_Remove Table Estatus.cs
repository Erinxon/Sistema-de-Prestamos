using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prestamos.Infrastructure.Migrations
{
    public partial class RemoveTableEstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Clientes__IdEsta__3A81B327",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK__Usuarios__IdEsta__31EC6D26",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Estatus");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_IdEstatus",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_IdEstatus",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "IdEstatus",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "IdEstatus",
                table: "Clientes");

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2021, 12, 30, 13, 47, 49, 343, DateTimeKind.Utc).AddTicks(2029), new DateTime(2021, 12, 30, 13, 47, 49, 343, DateTimeKind.Utc).AddTicks(1579) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2021, 12, 30, 13, 47, 49, 342, DateTimeKind.Utc).AddTicks(4485), new DateTime(2021, 12, 30, 13, 47, 49, 342, DateTimeKind.Utc).AddTicks(3419) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2021, 12, 30, 13, 47, 49, 342, DateTimeKind.Utc).AddTicks(5482), new DateTime(2021, 12, 30, 13, 47, 49, 342, DateTimeKind.Utc).AddTicks(5479) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEstatus",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEstatus",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Estatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstatusClientes = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estatus", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizado", "FechaCreado" },
                values: new object[] { new DateTime(2021, 12, 25, 15, 16, 56, 8, DateTimeKind.Utc).AddTicks(721), new DateTime(2021, 12, 25, 15, 16, 56, 8, DateTimeKind.Utc).AddTicks(368) });

            migrationBuilder.InsertData(
                table: "Estatus",
                columns: new[] { "Id", "EstatusClientes" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaActualizado", "FechaCreado", "IdEstatus" },
                values: new object[] { new DateTime(2021, 12, 25, 15, 16, 56, 7, DateTimeKind.Utc).AddTicks(4555), new DateTime(2021, 12, 25, 15, 16, 56, 7, DateTimeKind.Utc).AddTicks(3655), 1 });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaActualizado", "FechaCreado", "IdEstatus" },
                values: new object[] { new DateTime(2021, 12, 25, 15, 16, 56, 7, DateTimeKind.Utc).AddTicks(5313), new DateTime(2021, 12, 25, 15, 16, 56, 7, DateTimeKind.Utc).AddTicks(5310), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdEstatus",
                table: "Usuarios",
                column: "IdEstatus");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdEstatus",
                table: "Clientes",
                column: "IdEstatus");

            migrationBuilder.AddForeignKey(
                name: "FK__Clientes__IdEsta__3A81B327",
                table: "Clientes",
                column: "IdEstatus",
                principalTable: "Estatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Usuarios__IdEsta__31EC6D26",
                table: "Usuarios",
                column: "IdEstatus",
                principalTable: "Estatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
