using Prestamos.Core.Entities;
using Prestamos.Core.Entities.Enums;
using Prestamos.Infrastructure.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestamos.Infrastructure.DbContexts
{
    public static class DefaultData
    {
        public static Role[] GetDefaultDataRoles()
        {
            var roles = new Role[]
            {
                new Role()
               {
                   Id = 1,
                   Roles = RolesUsuario.Admin
               },
               new Role()
               {
                   Id = 2,
                   Roles = RolesUsuario.Prestador
               },
               new Role()
               {
                   Id = 3,
                   Roles = RolesUsuario.Cobrador
               }
            };
            return roles;
        }

        public static EstatusCrediticio[] GetDefaultDataEstatusCrediticio()
        {
            var estatusCrediticios = new EstatusCrediticio[]
            {
                new EstatusCrediticio()
               {
                   Id = 1,
                   EstatusCrediticios = EstatuCrediticioCliente.Libre
               },
               new EstatusCrediticio()
               {
                   Id = 2,
                   EstatusCrediticios = EstatuCrediticioCliente.CreditosOcupados
               },
               new EstatusCrediticio()
               {
                   Id = 3,
                   EstatusCrediticios = EstatuCrediticioCliente.Atrasados
               },
               new EstatusCrediticio()
               {
                   Id = 4,
                   EstatusCrediticios = EstatuCrediticioCliente.PrestamosVencidos
               }
            };
            return estatusCrediticios;
        }

        public static EstatusPrestamo[] GetDefaultDataEstatusPrestamo()
        {
            var estatusPrestamos = new EstatusPrestamo[]
            {
               new EstatusPrestamo()
               {
                   Id = 1,
                       EstatusPrestamos = EstatusPrestamosClientes.Pendiente
               },
               new EstatusPrestamo()
               {
                   Id = 2,
                   EstatusPrestamos = EstatusPrestamosClientes.Pagado
               },
               new EstatusPrestamo()
               {
                   Id = 3,
                   EstatusPrestamos = EstatusPrestamosClientes.Abono
               },
               new EstatusPrestamo()
               {
                  Id = 4,
                  EstatusPrestamos = EstatusPrestamosClientes.Atraso
               }
            };
            return estatusPrestamos;
        }

        public static PeriodoPago[] GetDefaultDataPeriodoPago()
        {
            var periodosDePagos = new PeriodoPago[]
            {
                new PeriodoPago()
                {
                   Id = 1,
                   PeriodoDePagos = PeriodoDePagos.Diario
                },
                new PeriodoPago()
                {
                   Id = 2,
                   PeriodoDePagos = PeriodoDePagos.Semanal
                },
                new PeriodoPago()
                {
                   Id = 3,
                   PeriodoDePagos = PeriodoDePagos.Quincenal
                },
                new PeriodoPago()
                {
                   Id = 4,
                   PeriodoDePagos = PeriodoDePagos.Mensual
                },
                new PeriodoPago()
                {
                   Id = 5,
                   PeriodoDePagos = PeriodoDePagos.Anual
                }
            };
            return periodosDePagos;
        }

        public static Direccion[] GetDefaultDataDireccion()
        {
            var direcciones = new Direccion[]
            {
                new Direccion
                {
                    Id = 1,
                    Provincia = "Santo Domingo",
                    Calle = "Desconocida",
                    Numero = "13"
                },
                new Direccion
                {
                    Id = 2,
                    Provincia = "Santo Domingo 2",
                    Calle = "Desconocida",
                    Numero = "14"
                },
                new Direccion
                {
                    Id = 3,
                    Provincia = "Santo Domingo 3",
                    Calle = "Desconocida",
                    Numero = "15"
                },
                new Direccion
                {
                    Id = 4,
                    Provincia = "Santo Domingo 4",
                    Calle = "Desconocida",
                    Numero = "16"
                }
            };
            return direcciones;
        }

        public static Usuario[] GetDefaultDataUsuario()
        {
            var usuarios = new Usuario[]
            {
                new Usuario
                {
                    Id = 3,
                    Nombres = "Super",
                    Apellidos = "Admin",
                    Cedula = "10015221545",
                    Email = "admin@gmail.com",
                    Telefono = "8294551565",
                    IdDireccion = 4,
                    IdRol = (int) RolesUsuario.Admin,
                    Password = "123456789".ToEncryptedPassword(),
                    FechaCreado =  DateTime.UtcNow,
                    FechaActualizado = DateTime.UtcNow,
                },
                new Usuario
                {
                    Id = 1,
                    Nombres = "Erinxon",
                    Apellidos = "Santana",
                    Cedula = "17895222545",
                    Email = "erinxon@gmail.com",
                    Telefono = "8294155565",
                    IdDireccion = 1,
                    IdRol = (int) RolesUsuario.Prestador,
                    Password = "123456789".ToEncryptedPassword(),
                    FechaCreado =  DateTime.UtcNow,
                    FechaActualizado = DateTime.UtcNow,
                },
                new Usuario
                {
                    Id = 2,
                    Nombres = "Prueba prueba2",
                    Apellidos = "Prueba prueba2",
                    Cedula = "17495221545",
                    Email = "prueba2@gmail.com",
                    Telefono = "8294555565",
                    IdDireccion = 2,
                    IdRol = (int) RolesUsuario.Cobrador,
                    Password = "123456789".ToEncryptedPassword(),
                    FechaCreado =  DateTime.UtcNow,
                    FechaActualizado = DateTime.UtcNow,
                }
            };
            return usuarios;
        }

        public static Empresa[] GetDefaultDataEmpresa()
        {
            var empresa = new Empresa[]
            {
                new Empresa
                {
                    Id = 1,
                    Nombre = "Prueba",
                    Rnc = "875223236",
                    Telefono = "5556232365",
                    Email = "prueba@gmail.com",
                    FechaCreado = DateTime.UtcNow,
                    FechaActualizado = DateTime.UtcNow,
                    IdDireccion = 3,
                    IdAdministrador = 1
                }
            };
            return empresa;
        }

    }
}
