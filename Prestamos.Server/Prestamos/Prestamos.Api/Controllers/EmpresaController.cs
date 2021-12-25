using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prestamos.Core.Entities;
using Prestamos.Infrastructure.ApiResponse;
using Prestamos.Infrastructure.Dtos.EmpresasDtos;
using Prestamos.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prestamos.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize(Roles = "Prestador")]
    public class EmpresaController : PrestamoControllerBase
    {
        public EmpresaController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        // GET: api/Empresa
        [HttpGet]
        public async Task<ActionResult<EmpresaDto>> GetAll()
        {
            var response = new ApiResponse<EmpresaDto>();
            try
            {
                 var empresa = await _unitOfWork.Empresa.Get();
                 response.Data = _mapper.Map<EmpresaDto>(empresa);
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

        // PUT: api/Empresa/1
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateEmpresaDto empresaDto)
        {
            var response = new ApiResponse<EmpresaDto>();
            try
            {
                var empresa = await this._unitOfWork.Empresa.Get(id);
                if (empresa is null)
                {
                    response.Succeeded = false;
                    response.Message = "No se encontro la empresa!";
                    response.StatusCode = StatusCodes.Status404NotFound;
                    return NotFound(response);
                }
                empresa.Nombre = empresaDto.Nombre;
                empresa.Rnc = empresaDto.Rnc;
                empresa.Telefono = empresaDto.Telefono;
                empresa.Email = empresaDto.Email;
                empresa.Direccion = _mapper.Map<Direccion>(empresaDto.Direccion);
                await this._unitOfWork.Empresa.Update(empresa);
                await this._unitOfWork.SavechangesAsync();
                await this._unitOfWork.Direcciones.Update(empresa.Direccion);  
                await this._unitOfWork.SavechangesAsync();
                response.Data = _mapper.Map<EmpresaDto>(empresa);
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
