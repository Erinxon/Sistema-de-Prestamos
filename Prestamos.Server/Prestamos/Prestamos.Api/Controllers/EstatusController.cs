using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class EstatusController : PrestamoControllerBase
    {

        public EstatusController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            
        }

        // GET: api/Estatus
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<EstatusDto>>>> GetAll()
        {
            var response = new ApiResponse<IEnumerable<EstatusDto>>();
            try
            {
                var estatuses = await _unitOfWork.Estatus.GetAll();
                response.Data = _mapper.Map<IEnumerable<EstatusDto>>(estatuses);
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

        // GET: api/Estatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<EstatusDto>>> Get(int id)
        {
            var response = new ApiResponse<EstatusDto>();
            try
            {
                var estatus = await _unitOfWork.Estatus.GetById(id);

                if (estatus == null)
                {
                    response.Succeeded = false;
                    response.Message = "No se encontro el estatus!";
                    response.StatusCode = StatusCodes.Status404NotFound;
                    return NotFound(response);
                }
                response.Data = _mapper.Map<EstatusDto>(estatus);
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
