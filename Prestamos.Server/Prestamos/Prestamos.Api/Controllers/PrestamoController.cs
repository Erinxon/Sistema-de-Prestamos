using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prestamos.Core.Entities;
using Prestamos.Core.Entities.Enums;
using Prestamos.Infrastructure.ApiResponse;
using Prestamos.Infrastructure.Dtos.PrestamosDtos;
using Prestamos.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prestamos.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize]
    public class PrestamosController : PrestamoControllerBase
    {
        public PrestamosController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        // GET: api/Prestamos
        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<PrestamoDto>>>> GetAll([FromQuery] Pagination pagination)
        {
            var response = new PagedResponse<IEnumerable<PrestamoDto>>(pagination);
            try
            {
                var prestamos = await _unitOfWork.Prestamos.GetAll(pagination);
                response.Data = _mapper.Map<IEnumerable<PrestamoDto>>(prestamos);
                response.pagination = pagination;
                response.pagination.TotalRegistros = await this._unitOfWork.Prestamos.GetCount();
                response.StatusCode = StatusCodes.Status200OK;
            }
            catch (Exception ex)
            {
                response.Message = "Ocurio un error al obtener los datos!";
                response.Succeeded = false;
                response.StatusCode = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }
            
            return Ok(response);
        }

        // GET: api/Prestamos/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<PrestamoDto>>> Get(int id)
        {
            var response = new ApiResponse<PrestamoDto>();
            try
            {
                var prestamo = await this._unitOfWork.Prestamos.GetById(id);
                if (prestamo is null)
                {
                    response.Succeeded = false;
                    response.Message = "No se encontro el prestamo!";
                    response.StatusCode = StatusCodes.Status404NotFound;
                    return NotFound(response);
                }
                response.Data = _mapper.Map<PrestamoDto>(prestamo);
                response.StatusCode = StatusCodes.Status200OK;
            }
            catch (Exception ex)
            {
                response.Message = "Ocurio un error al obtener los datos!";
                response.Succeeded = false;
                response.StatusCode = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }
            return Ok(response);
        }

        // GET: api/Prestamos/GetByCliente/
        [HttpGet("GetByCliente/{cedula}")]
        public async Task<ActionResult<ApiResponse<PrestamoDto>>> GetByCliente(string cedula)
        {
            var response = new ApiResponse<PrestamoDto>();
            try
            {
                var isClienteExist = await this._unitOfWork.Clientes.GetByCedula(cedula);
                if (isClienteExist is null)
                {
                    response.Succeeded = false;
                    response.Message = "No se encontró el cliente";
                    response.StatusCode = StatusCodes.Status404NotFound;
                    return NotFound(response);
                }
                var prestamo = await this._unitOfWork.Prestamos.GetByCedulaCliente(cedula);
                if (prestamo is null)
                {
                    response.Succeeded = false;
                    response.Message = "No se encontró nungun prestamo activo de dicho cliente";
                    response.StatusCode = StatusCodes.Status404NotFound;
                    return NotFound(response);
                }
                response.Data = _mapper.Map<PrestamoDto>(prestamo);
                response.StatusCode = StatusCodes.Status200OK;
            }
            catch (Exception ex)
            {
                response.Message = "Ocurio un error al obtener los datos!";
                response.Succeeded = false;
                response.StatusCode = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }
            return Ok(response);
        }


        // POST: api/Prestamos
        [HttpPost]
        public async Task<ActionResult<ApiResponse<PrestamoDto>>> Post([FromBody] AddPrestamoDto prestamoDto)
        {
            var response = new ApiResponse<PrestamoDto>();
            try
            {
                var prestamo = _mapper.Map<Prestamo>(prestamoDto);
                prestamo.IdEstatusPrestamo = (int)EstatusPrestamosClientes.Pendiente;
                await this._unitOfWork.Prestamos.Add(prestamo);
                await this._unitOfWork.SavechangesAsync();
  
                //Actualizar es el estatus crediticio del cliente
                await this._unitOfWork.Clientes.
                    CambiarEstatusCrediticio(prestamo.IdCliente, (int) EstatuCrediticioCliente.CreditosOcupados);
                await this._unitOfWork.SavechangesAsync();
                response.Data = _mapper.Map<PrestamoDto>(prestamo);
                response.StatusCode = StatusCodes.Status201Created;
            }
            catch (Exception ex)
            {
                response.Message = "Ocurrio un error";
                response.Succeeded = false;
                response.StatusCode = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }
            return Created("api/Prestamos", response);
        }

        // PUT: api/api/Prestamos
        [HttpPut("Pagar/{id}")]
        public async Task<ActionResult<ApiResponse<PrestamoDto>>> Put(int id, [FromBody] PrestamoDto prestamoDto) 
        {
            var response = new ApiResponse<PrestamoDto>();
            try
            {
                var prestamo = await this._unitOfWork.Prestamos.GetById(id);
                if (prestamo is null)
                {
                    response.Succeeded = false;
                    response.Message = "No se encontró el Prestamo";
                    response.StatusCode = StatusCodes.Status404NotFound;
                    return NotFound(response);
                }

                //Change estatus prestamo
                prestamo.IdEstatusPrestamo = prestamoDto.EstatusPrestamo.Id;
                prestamo.EstatusPrestamo = _mapper.Map<EstatusPrestamo>(prestamoDto.EstatusPrestamo);
                prestamo.DetallePrestamos = null;

                //Mappper detalle prestamo
                var detalle = _mapper.Map<List<DetallePrestamo>>(prestamoDto.DetallePrestamos);
                detalle.ForEach(p =>
                {
                    p.EstatusPrestamo = null;
                });

                //Update prestamo
                prestamo = await this._unitOfWork.Prestamos.Pagar(prestamo);
                await this._unitOfWork.SavechangesAsync();

                //Update detalle prestamo
                await this._unitOfWork.DetallesPrestamos.Update(detalle);
                await this._unitOfWork.SavechangesAsync();

                prestamo.DetallePrestamos = detalle;
                response.Data = _mapper.Map<PrestamoDto>(prestamo);
                response.StatusCode = StatusCodes.Status200OK;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Succeeded = false;
                response.StatusCode = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
