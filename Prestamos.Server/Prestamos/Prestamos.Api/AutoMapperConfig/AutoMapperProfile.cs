using AutoMapper;
using Prestamos.Core.Entities;
using Prestamos.Infrastructure.Dtos.ClientesDtos;
using Prestamos.Infrastructure.Dtos.DirecionesDtos;
using Prestamos.Infrastructure.Dtos.UsuariosDtos;
using Prestamos.Infrastructure.Dtos.EmpresasDtos;
using Prestamos.Infrastructure.Dtos.EnumsDtos;
using Prestamos.Infrastructure.Dtos.PrestamosDtos;
using Prestamos.Infrastructure.Dtos.PrestamosDtos.DetallePrestamosDto;
using Prestamos.Infrastructure.Dtos.AuthDtos;
namespace Prestamos.Api.AutoMapperConfig
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Direciones
            CreateMap<Direccion, DireccionDto>();
            CreateMap<UpdateDireccionDto, Direccion>();
            CreateMap<AddDireccionDto, Direccion>();
            #endregion

            #region Usuarios
            CreateMap<UsuarioDto, Usuario>().ReverseMap();
            CreateMap<AddUsuarioDto, Usuario>().ReverseMap();
            CreateMap<UpdateUsuarioDto, Usuario>().ReverseMap();
            #endregion

            #region Clientes
            CreateMap<ClienteDto, Cliente>().ReverseMap();
            CreateMap<AddClienteDto, Cliente>().ReverseMap();
            CreateMap<UpdateClienteDto, Cliente>().ReverseMap();
            #endregion

            #region Enums
            CreateMap<EstatusDto, Estatus>().ReverseMap();
            CreateMap<EstatusCrediticioDto, EstatusCrediticio>().ReverseMap();
            CreateMap<EstatusPrestamoDto, EstatusPrestamo>().ReverseMap();
            CreateMap<PeriodoPagoDto, PeriodoPago>().ReverseMap();
            CreateMap<RolDto, Role>().ReverseMap();
            #endregion

            #region Empresas
            CreateMap<EmpresaDto, Empresa>().ReverseMap();
            CreateMap<UpdateEmpresaDto, Empresa>().ReverseMap();
            #endregion

            #region Prestamos
            CreateMap<PrestamoDto, Prestamo>().ReverseMap();
            CreateMap<AddPrestamoDto, Prestamo>().ReverseMap();
            CreateMap<DetallePrestamoDto, DetallePrestamo>().ReverseMap();
            CreateMap<AddDetallePrestamoDto, DetallePrestamo>().ReverseMap();
            #endregion
        }
    }
}
