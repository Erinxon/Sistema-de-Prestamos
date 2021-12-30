using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Prestamos.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Provincia = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Calle = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstatusCrediticio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstatusCrediticios = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstatusCrediticio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstatusPrestamos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstatusPrestamos = table.Column<int>(type: "int", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstatusPrestamos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeriodoPago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodoDePagos = table.Column<int>(type: "int", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodoPago", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Roles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Cedula = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    IdDireccion = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    IdEstatusCrediticio = table.Column<int>(type: "int", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaActualizado = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Clientes__IdDire__398D8EEE",
                        column: x => x.IdDireccion,
                        principalTable: "Direccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Clientes__IdEsta__3B75D760",
                        column: x => x.IdEstatusCrediticio,
                        principalTable: "EstatusCrediticio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Cedula = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    IdDireccion = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaActualizado = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Usuarios__IdDire__30F848ED",
                        column: x => x.IdDireccion,
                        principalTable: "Direccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Usuarios__IdRol__32E0915F",
                        column: x => x.IdRol,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    RNC = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Telefono = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaActualizado = table.Column<DateTime>(type: "datetime", nullable: true),
                    IdDireccion = table.Column<int>(type: "int", nullable: true),
                    IdAdministrador = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Empresa__IdAdmin__36B12243",
                        column: x => x.IdAdministrador,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Empresa__IdDirec__35BCFE0A",
                        column: x => x.IdDireccion,
                        principalTable: "Direccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Interes = table.Column<decimal>(type: "decimal(5,3)", nullable: false),
                    Cuotas = table.Column<int>(type: "int", nullable: false),
                    Capital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdPeriodoPago = table.Column<int>(type: "int", nullable: false),
                    FechaCreado = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaCulminacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdEstatusPrestamo = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioUtorizador = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestamos_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prestamos_EstatusPrestamos_IdEstatusPrestamo",
                        column: x => x.IdEstatusPrestamo,
                        principalTable: "EstatusPrestamos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prestamos_PeriodoPago_IdPeriodoPago",
                        column: x => x.IdPeriodoPago,
                        principalTable: "PeriodoPago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prestamos_Usuarios_IdUsuarioUtorizador",
                        column: x => x.IdUsuarioUtorizador,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetallePrestamos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCuota = table.Column<int>(type: "int", nullable: false),
                    CuotaPagar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InteresPagar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CapitalAmortizado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pagado = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CapitalPendiente = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime", nullable: false),
                    IdEstatusPrestamo = table.Column<int>(type: "int", nullable: false),
                    IdPrestamo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePrestamos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallePrestamos_EstatusPrestamos_IdEstatusPrestamo",
                        column: x => x.IdEstatusPrestamo,
                        principalTable: "EstatusPrestamos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallePrestamos_Prestamos_IdPrestamo",
                        column: x => x.IdPrestamo,
                        principalTable: "Prestamos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Direccion",
                columns: new[] { "Id", "Calle", "Numero", "Provincia" },
                values: new object[,]
                {
                    { 1, "Desconocida", "13", "Santo Domingo" },
                    { 2, "Desconocida", "14", "Santo Domingo 2" },
                    { 3, "Desconocida", "15", "Santo Domingo 3" },
                    { 4, "Desconocida", "16", "Santo Domingo 4" }
                });

            migrationBuilder.InsertData(
                table: "EstatusCrediticio",
                columns: new[] { "Id", "EstatusCrediticios" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "EstatusPrestamos",
                columns: new[] { "Id", "EstatusPrestamos" },
                values: new object[,]
                {
                    { 4, 4 },
                    { 3, 3 },
                    { 2, 2 },
                    { 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "PeriodoPago",
                columns: new[] { "Id", "PeriodoDePagos" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Roles" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Cedula", "Email", "FechaActualizado", "FechaCreado", "IdDireccion", "IdRol", "Nombres", "Password", "Telefono" },
                values: new object[] { 3, "Admin", "10015221545", "admin@gmail.com", new DateTime(2021, 12, 30, 14, 32, 34, 724, DateTimeKind.Utc).AddTicks(4), new DateTime(2021, 12, 30, 14, 32, 34, 723, DateTimeKind.Utc).AddTicks(9223), 4, 1, "Super", "15e2b0d3c33891ebb0f1ef609ec419420c20e320ce94c65fbc8c3312448eb225", "8294551565" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Cedula", "Email", "FechaActualizado", "FechaCreado", "IdDireccion", "IdRol", "Nombres", "Password", "Telefono" },
                values: new object[] { 1, "Santana", "17895222545", "erinxon@gmail.com", new DateTime(2021, 12, 30, 14, 32, 34, 724, DateTimeKind.Utc).AddTicks(680), new DateTime(2021, 12, 30, 14, 32, 34, 724, DateTimeKind.Utc).AddTicks(677), 1, 2, "Erinxon", "15e2b0d3c33891ebb0f1ef609ec419420c20e320ce94c65fbc8c3312448eb225", "8294155565" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Apellidos", "Cedula", "Email", "FechaActualizado", "FechaCreado", "IdDireccion", "IdRol", "Nombres", "Password", "Telefono" },
                values: new object[] { 2, "Prueba prueba2", "17495221545", "prueba2@gmail.com", new DateTime(2021, 12, 30, 14, 32, 34, 724, DateTimeKind.Utc).AddTicks(800), new DateTime(2021, 12, 30, 14, 32, 34, 724, DateTimeKind.Utc).AddTicks(799), 2, 3, "Prueba prueba2", "15e2b0d3c33891ebb0f1ef609ec419420c20e320ce94c65fbc8c3312448eb225", "8294555565" });

            migrationBuilder.InsertData(
                table: "Empresa",
                columns: new[] { "Id", "Email", "FechaActualizado", "FechaCreado", "IdAdministrador", "IdDireccion", "Nombre", "RNC", "Telefono" },
                values: new object[] { 1, "prueba@gmail.com", new DateTime(2021, 12, 30, 14, 32, 34, 724, DateTimeKind.Utc).AddTicks(5119), new DateTime(2021, 12, 30, 14, 32, 34, 724, DateTimeKind.Utc).AddTicks(4806), 1, 3, "Prueba", "875223236", "5556232365" });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Cedula",
                table: "Clientes",
                column: "Cedula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdDireccion",
                table: "Clientes",
                column: "IdDireccion");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_IdEstatusCrediticio",
                table: "Clientes",
                column: "IdEstatusCrediticio");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePrestamos_IdEstatusPrestamo",
                table: "DetallePrestamos",
                column: "IdEstatusPrestamo");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePrestamos_IdPrestamo",
                table: "DetallePrestamos",
                column: "IdPrestamo");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_IdAdministrador",
                table: "Empresa",
                column: "IdAdministrador");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_IdDireccion",
                table: "Empresa",
                column: "IdDireccion");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_IdCliente",
                table: "Prestamos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_IdEstatusPrestamo",
                table: "Prestamos",
                column: "IdEstatusPrestamo");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_IdPeriodoPago",
                table: "Prestamos",
                column: "IdPeriodoPago");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_IdUsuarioUtorizador",
                table: "Prestamos",
                column: "IdUsuarioUtorizador");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdDireccion",
                table: "Usuarios",
                column: "IdDireccion");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdRol",
                table: "Usuarios",
                column: "IdRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallePrestamos");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "EstatusPrestamos");

            migrationBuilder.DropTable(
                name: "PeriodoPago");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "EstatusCrediticio");

            migrationBuilder.DropTable(
                name: "Direccion");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
