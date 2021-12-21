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
    [Authorize(Roles = "Prestador")]
    public class RolesController : PrestamoControllerBase
    {
        public RolesController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<RolDto>>>> GetAll()
        {
            var response = new ApiResponse<IEnumerable<RolDto>>();
            try
            {
                var estatuses = await _unitOfWork.Roles.GetAll();
                response.Data = _mapper.Map<IEnumerable<RolDto>>(estatuses);
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

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<RolDto>>> Get(int id)
        {
            var response = new ApiResponse<RolDto>();
            try
            {
                var estatus = await _unitOfWork.Roles.GetById(id);

                if (estatus == null)
                {
                    response.Succeeded = false;
                    response.Message = "No se encontro el rol!";
                    response.StatusCode = StatusCodes.Status404NotFound;
                    return NotFound(response);
                }
                response.Data = _mapper.Map<RolDto>(estatus);
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
