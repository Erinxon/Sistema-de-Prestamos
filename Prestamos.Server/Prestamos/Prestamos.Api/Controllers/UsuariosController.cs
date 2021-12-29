using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prestamos.Core.Entities;
using Prestamos.Core.Entities.Enums;
using Prestamos.Infrastructure.ApiResponse;
using Prestamos.Infrastructure.Dtos.UsuariosDtos;
using Prestamos.Infrastructure.Implementations;
using Prestamos.Infrastructure.Interfaces;
using Prestamos.Infrastructure.Tools;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prestamos.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize(Roles = "Prestador")]
    public class UsuariosController : PrestamoControllerBase
    {
        public UsuariosController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<UsuarioDto>>>> GetAll([FromQuery] Pagination pagination)
        {
            var response = new PagedResponse<IEnumerable<UsuarioDto>>(pagination);
            try
            {
                var clientes = await this._unitOfWork.Usuarios.GetAll(pagination);
                response.Data = _mapper.Map<IEnumerable<UsuarioDto>>(clientes);
                response.pagination.TotalRegistros = await this._unitOfWork.Usuarios.GetCount();
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

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<UsuarioDto>>> Get(int id)
        {
            var response = new ApiResponse<UsuarioDto>();
            try
            {
                var usuario = await this._unitOfWork.Usuarios.GetById(id);
                if (usuario is null)
                {
                    response.Succeeded = false;
                    response.Message = "No se encontro el usuario!";
                    response.StatusCode = StatusCodes.Status404NotFound;
                    return NotFound(response);
                }
                response.Data = _mapper.Map<UsuarioDto>(usuario);
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

        [HttpGet("search/{text}")]
        [Authorize]
        public async Task<ActionResult<PagedResponse<IEnumerable<UsuarioDto>>>> Search(string text, [FromQuery] Pagination pagination)
        {

            var response = new PagedResponse<IEnumerable<UsuarioDto>>(pagination);
            try
            {
                var cliente = await this._unitOfWork.Usuarios.Filter(text, pagination);
                response.Data = _mapper.Map<IEnumerable<UsuarioDto>>(cliente);
                response.pagination.TotalRegistros = await this._unitOfWork.Usuarios.GetCount();
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

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateUsuarioDto usuarioDto)
        {
            var response = new ApiResponse<UsuarioDto>();
            try
            {
                var usuario = await this._unitOfWork.Usuarios.GetById(id);
                if (usuario is null)
                {
                    response.Succeeded = false;
                    response.Message = "No se encontro el usuario!";
                    response.StatusCode = StatusCodes.Status404NotFound;
                    return NotFound(response);
                }
                usuario.Nombres = usuarioDto.Nombres;
                usuario.Apellidos = usuarioDto.Apellidos;
                usuario.Cedula = usuarioDto.Cedula;
                usuario.Email = usuarioDto.Email;
                usuario.IdRol = usuarioDto.IdRol;
                usuario.Rol = null;
                await this._unitOfWork.Direcciones.Update(usuario.Direccion);
                await this._unitOfWork.SavechangesAsync();
                await this._unitOfWork.Usuarios.Update(usuario);
                await this._unitOfWork.SavechangesAsync();
                response.Data = _mapper.Map<UsuarioDto>(usuario);
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

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> Post([FromBody] AddUsuarioDto usuarioDto)
        {
            var response = new ApiResponse<UsuarioDto>();
            try
            {
                var usuario = _mapper.Map<Usuario>(usuarioDto);
                usuario.Password = usuario.Password.ToEncryptedPassword();
                usuario.IdEstatus = (int) EstatusClientes.Activo;
                await this._unitOfWork.Direcciones.Add(usuario.Direccion);
                await this._unitOfWork.SavechangesAsync();
                usuario.IdDireccion = usuario.Direccion.Id;
                await this._unitOfWork.Usuarios.Add(usuario);
                await this._unitOfWork.SavechangesAsync();
                response.Data = _mapper.Map<UsuarioDto>(usuario);
                response.StatusCode = StatusCodes.Status200OK;
            }
            catch (Exception)
            {
                response.Message = "Ocurio un error al obtener los datos!";
                response.Succeeded = false;
                response.StatusCode = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }
            return Created("api/Usuarios", response);
        }


        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new ApiResponse<UsuarioDto>();
            try
            {
                var usuario = await this._unitOfWork.Usuarios.GetById(id);
                if (usuario is null)
                {
                    response.Message = "No se encontro el usuario!";
                    response.Succeeded = false;
                    response.StatusCode = StatusCodes.Status404NotFound;
                    return BadRequest(response);
                }
                await this._unitOfWork.Usuarios.Delete(usuario);
                await this._unitOfWork.SavechangesAsync();
                await this._unitOfWork.Direcciones.Delete(usuario.Direccion);
                await this._unitOfWork.SavechangesAsync();
            }
            catch (Exception)
            {
                response.Message = "Ocurio un error al obtener los datos!";
                response.Succeeded = false;
                response.StatusCode = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }
            return NoContent();
        }
    }
}
