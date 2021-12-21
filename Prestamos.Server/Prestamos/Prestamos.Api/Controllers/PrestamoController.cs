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
        public async Task<ActionResult<ApiResponse<IEnumerable<PrestamoDto>>>> GetAll([FromQuery] int idUsuario)
        {
            var response = new ApiResponse<IEnumerable<PrestamoDto>>();
            try
            {
                var usuario = await _unitOfWork.Usuarios.GetById(idUsuario);

                if (usuario is null)
                {
                    response.Succeeded = false;
                    response.Message = "No se encontro el prestamo!";
                    response.StatusCode = StatusCodes.Status404NotFound;
                    return NotFound(response);
                }
                RolesUsuario rol = usuario.Rol.Roles;
                var prestamos = await _unitOfWork.Prestamos.GetAll(idUsuario, rol);
                response.Data = _mapper.Map<IEnumerable<PrestamoDto>>(prestamos);
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

        // POST: api/Prestamos
        [HttpPost]
        public async Task<ActionResult<PrestamoDto>> Post([FromBody] AddPrestamoDto prestamoDto)
        {
            var response = new ApiResponse<PrestamoDto>();
            try
            {
                var prestamo = _mapper.Map<Prestamo>(prestamoDto);
                await this._unitOfWork.Prestamos.Add(prestamo);
                await this._unitOfWork.SavechangesAsync();
                response.Data = _mapper.Map<PrestamoDto>(prestamo);
                response.StatusCode = StatusCodes.Status201Created;
            }
            catch (Exception)
            {
                response.Message = "Ocurio un error al obtener los datos!";
                response.Succeeded = false;
                response.StatusCode = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            return Created("api/Prestamos/", response);
        }
    }
}
