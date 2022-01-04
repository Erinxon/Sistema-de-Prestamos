using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Prestamos.Infrastructure.Migrations
{
    public partial class Initialpostgresql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Provincia = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    Calle = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstatusCrediticio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EstatusCrediticios = table.Column<int>(type: "integer", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstatusCrediticio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstatusPrestamos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EstatusPrestamos = table.Column<int>(type: "integer", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstatusPrestamos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeriodoPago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PeriodoDePagos = table.Column<int>(type: "integer", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodoPago", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Roles = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombres = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    Cedula = table.Column<string>(type: "character varying(11)", unicode: false, maxLength: 11, nullable: false),
                    IdDireccion = table.Column<int>(type: "integer", nullable: false),
                    Telefono = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: true),
                    IdEstatusCrediticio = table.Column<int>(type: "integer", nullable: false),
                    FechaCreado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    FechaActualizado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombres = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    Cedula = table.Column<string>(type: "character varying(11)", unicode: false, maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "character varying(250)", unicode: false, maxLength: 250, nullable: false),
                    IdDireccion = table.Column<int>(type: "integer", nullable: false),
                    Telefono = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: true),
                    IdRol = table.Column<int>(type: "integer", nullable: false),
                    Password = table.Column<string>(type: "character varying(256)", unicode: false, maxLength: 256, nullable: false),
                    FechaCreado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    FechaActualizado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    RNC = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: true),
                    Telefono = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    FechaCreado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    FechaActualizado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    IdDireccion = table.Column<int>(type: "integer", nullable: true),
                    IdAdministrador = table.Column<int>(type: "integer", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Interes = table.Column<decimal>(type: "numeric(5,3)", nullable: false),
                    Cuotas = table.Column<int>(type: "integer", nullable: false),
                    Capital = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    IdPeriodoPago = table.Column<int>(type: "integer", nullable: false),
                    FechaCreado = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    FechaCulminacion = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IdEstatusPrestamo = table.Column<int>(type: "integer", nullable: false),
                    IdUsuarioUtorizador = table.Column<int>(type: "integer", nullable: false),
                    IdCliente = table.Column<int>(type: "integer", nullable: false)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumeroCuota = table.Column<int>(type: "integer", nullable: false),
                    CuotaPagar = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    InteresPagar = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CapitalAmortizado = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Pagado = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CapitalPendiente = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    FechaPago = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IdEstatusPrestamo = table.Column<int>(type: "integer", nullable: false),
                    IdPrestamo = table.Column<int>(type: "integer", nullable: false)
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
                values: new object[,]
                {
                    { 3, "Admin", "10015221545", "admin@gmail.com", new DateTimeOffset(new DateTime(2022, 1, 4, 13, 45, 43, 132, DateTimeKind.Unspecified).AddTicks(6407), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 1, 4, 13, 45, 43, 132, DateTimeKind.Unspecified).AddTicks(5963), new TimeSpan(0, 0, 0, 0, 0)), 4, 1, "Super", "15e2b0d3c33891ebb0f1ef609ec419420c20e320ce94c65fbc8c3312448eb225", "8294551565" },
                    { 1, "Santana", "17895222545", "erinxon@gmail.com", new DateTimeOffset(new DateTime(2022, 1, 4, 13, 45, 43, 132, DateTimeKind.Unspecified).AddTicks(7085), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 1, 4, 13, 45, 43, 132, DateTimeKind.Unspecified).AddTicks(7081), new TimeSpan(0, 0, 0, 0, 0)), 1, 2, "Erinxon", "15e2b0d3c33891ebb0f1ef609ec419420c20e320ce94c65fbc8c3312448eb225", "8294155565" },
                    { 2, "Prueba prueba2", "17495221545", "prueba2@gmail.com", new DateTimeOffset(new DateTime(2022, 1, 4, 13, 45, 43, 132, DateTimeKind.Unspecified).AddTicks(7166), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 1, 4, 13, 45, 43, 132, DateTimeKind.Unspecified).AddTicks(7164), new TimeSpan(0, 0, 0, 0, 0)), 2, 3, "Prueba prueba2", "15e2b0d3c33891ebb0f1ef609ec419420c20e320ce94c65fbc8c3312448eb225", "8294555565" }
                });

            migrationBuilder.InsertData(
                table: "Empresa",
                columns: new[] { "Id", "Email", "FechaActualizado", "FechaCreado", "IdAdministrador", "IdDireccion", "Nombre", "RNC", "Telefono" },
                values: new object[] { 1, "prueba@gmail.com", new DateTimeOffset(new DateTime(2022, 1, 4, 13, 45, 43, 133, DateTimeKind.Unspecified).AddTicks(1420), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 1, 4, 13, 45, 43, 133, DateTimeKind.Unspecified).AddTicks(1092), new TimeSpan(0, 0, 0, 0, 0)), 1, 3, "Prueba", "875223236", "5556232365" });

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
