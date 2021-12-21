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
                   Roles = RolesUsuario.Prestador
               },
               new Role()
               {
                   Id = 2,
                   Roles = RolesUsuario.Cobrador
               }
            };
            return roles;
        }

        public static Estatus[] GetDefaultDataEstatus()
        {
            var estatus = new Estatus[]
            {
               new Estatus()
               {
                   Id = 1,
                   EstatusClientes = EstatusClientes.Activo
               },
               new Estatus()
               {
                   Id = 2,
                   EstatusClientes = EstatusClientes.Inactivo
               },
               new Estatus()
               {
                   Id = 3,
                   EstatusClientes = EstatusClientes.Eliminado
               }
            };
            return estatus;
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
                       EstatusPrestamos = EstatusPrestamosClientes.Pagado
               },
               new EstatusPrestamo()
               {
                   Id = 2,
                   EstatusPrestamos = EstatusPrestamosClientes.Pendiente
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
                    Id = 1,
                    Nombres = "Prueba prueba",
                    Apellidos = "Prueba prueba",
                    Cedula = "17895222545",
                    Email = "prueba1@gamil.com",
                    Telefono = "8294155565",
                    IdDireccion = 1,
                    IdEstatus  = 1,
                    IdRol = 1,
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
                    Email = "prueba2@gamil.com",
                    Telefono = "8294555565",
                    IdDireccion = 2,
                    IdEstatus  = 1,
                    IdRol = 2,
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
