using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prestamos.Core.Entities;
using Prestamos.Infrastructure.ApiResponse;
using Prestamos.Infrastructure.Dtos.EnumsDtos;
using Prestamos.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prestamos.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize(Roles = "Admin,Prestador")]
    public class EstatusPrestamosController : PrestamoControllerBase
    {
        public EstatusPrestamosController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        // GET: api/EstatusPrestamos
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<EstatusPrestamoDto>>>> GetAll()
        {
            var response = new ApiResponse<IEnumerable<EstatusPrestamoDto>>();
            try
            {
                var estatuses = await _unitOfWork.EstatusPrestamos.GetAll();
                response.Data = _mapper.Map<IEnumerable<EstatusPrestamoDto>>(estatuses);
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

        // GET: api/EstatusPrestamos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<EstatusPrestamoDto>>> Get(int id)
        {
            var response = new ApiResponse<EstatusPrestamoDto>();
            try
            {
                var estatus = await _unitOfWork.EstatusPrestamos.GetById(id);

                if (estatus == null)
                {
                    response.Succeeded = false;
                    response.Message = "No se encontro el estatus!";
                    response.StatusCode = StatusCodes.Status404NotFound;
                    return NotFound(response);
                }
                response.Data = _mapper.Map<EstatusPrestamoDto>(estatus);
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
    }
}
