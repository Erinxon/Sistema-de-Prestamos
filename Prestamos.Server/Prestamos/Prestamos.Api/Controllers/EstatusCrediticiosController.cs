using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prestamos.Core.Entities;
using Prestamos.Infrastructure.ApiResponse;
using Prestamos.Infrastructure.DbContexts;
using Prestamos.Infrastructure.Dtos.EnumsDtos;
using Prestamos.Infrastructure.Interfaces;

namespace Prestamos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EstatusCrediticiosController : PrestamoControllerBase
    {

        public EstatusCrediticiosController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
 
        }


        // GET: api/EstatusCrediticios
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<EstatusCrediticioDto>>>> GetAll()
        {
            var response = new ApiResponse<IEnumerable<EstatusCrediticioDto>>();
            try
            {
                var estatuses = await _unitOfWork.EstatusCrediticios.GetAll();
                response.Data = _mapper.Map<IEnumerable<EstatusCrediticioDto>>(estatuses);
                response.StatusCode = StatusCodes.Status200OK;
            }
            catch (Exception)
            {
                response.Message = "Ocurio un error al obtener los datos!";
                response.Succeeded = false;
                response.StatusCode = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            return Ok(response);
        }

        // GET: api/EstatusCrediticios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<EstatusCrediticio>>> Get(int id)
        {
            var response = new ApiResponse<EstatusCrediticio>();
            try
            {
                var estatus = await _unitOfWork.EstatusCrediticios.GetById(id);

                if (estatus == null)
                {
                    response.Succeeded = false;
                    response.Message = "No se encontro el estatus!";
                    response.StatusCode = StatusCodes.Status404NotFound;
                    return NotFound(response);
                }
                response.Data = _mapper.Map<EstatusCrediticio>(estatus);
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
