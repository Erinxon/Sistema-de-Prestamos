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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PeriodosPagosController : PrestamoControllerBase
    {
        public PeriodosPagosController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        // GET: api/PeriodosPagos
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<PeriodoPagoDto>>>> GetAll()
        {
            var response = new ApiResponse<IEnumerable<PeriodoPagoDto>>();
            try
            {
                var estatuses = await _unitOfWork.PeriodosPados.GetAll();
                response.Data = _mapper.Map<IEnumerable<PeriodoPagoDto>>(estatuses);
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

        // GET: api/PeriodosPagos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<PeriodoPagoDto>>> Get(int id)
        {
            var response = new ApiResponse<PeriodoPagoDto>();
            try
            {
                var estatus = await _unitOfWork.PeriodosPados.GetById(id);

                if (estatus == null)
                {
                    response.Succeeded = false;
                    response.Message = "No se encontro el periodo de pago!";
                    response.StatusCode = StatusCodes.Status404NotFound;
                    return NotFound(response);
                }
                response.Data = _mapper.Map<PeriodoPagoDto>(estatus);
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
