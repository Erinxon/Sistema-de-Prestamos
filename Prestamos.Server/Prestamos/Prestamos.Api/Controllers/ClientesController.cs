﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prestamos.Core.Entities;
using Prestamos.Infrastructure.ApiResponse;
using Prestamos.Infrastructure.Dtos.ClientesDtos;
using Prestamos.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prestamos.Core.Entities.Enums;
namespace Prestamos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : PrestamoControllerBase
    {
        public ClientesController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        // GET: api/Clientes
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<PagedResponse<IEnumerable<ClienteDto>>>> GetAll([FromQuery] Pagination pagination)
        {
            var response = new PagedResponse<IEnumerable<ClienteDto>>(pagination);
            try
            {
                var clientes = await this._unitOfWork.Clientes.GetAll(pagination);
                response.Data = _mapper.Map<IEnumerable<ClienteDto>>(clientes);
                response.StatusCode = StatusCodes.Status200OK;
                response.pagination.TotalRegistros = await this._unitOfWork.Clientes.GetCount();
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

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<Cliente>>> Get(int id)
        {

            var response = new ApiResponse<ClienteDto>();
            try
            {
                var cliente = await this._unitOfWork.Clientes.GetById(id);
                if (cliente is null)
                {
                    response.Succeeded = false;
                    response.Message = "No se encontro el cliente!";
                    response.StatusCode = StatusCodes.Status404NotFound;
                    return NotFound(response);
                }
                response.Data = _mapper.Map<ClienteDto>(cliente);
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
        public async Task<ActionResult<PagedResponse<IEnumerable<ClienteDto>>>> Search(string text, [FromQuery] Pagination pagination)
        {

            var response = new PagedResponse<IEnumerable<ClienteDto>>(pagination);
            try
            {
                var cliente = await this._unitOfWork.Clientes.Filter(text, pagination);
                response.Data = _mapper.Map<IEnumerable<ClienteDto>>(cliente);
                response.pagination.TotalRegistros = await this._unitOfWork.Clientes.GetCount();
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

        // PUT: api/Clientes/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Prestador")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateClienteDto clienteDto)
        {
            var response = new ApiResponse<ClienteDto>();
            try
            {
                var cliente = await this._unitOfWork.Clientes.GetById(id);
                if (cliente is null)
                {
                    response.Succeeded = false;
                    response.Message = "No se encontro el cliente!";
                    response.StatusCode = StatusCodes.Status404NotFound;
                    return NotFound(response);
                }
                cliente.Nombres = clienteDto.Nombres;
                cliente.Apellidos = clienteDto.Apellidos;
                cliente.Cedula = clienteDto.Cedula;
                cliente.Telefono = clienteDto.Telefono;
                cliente.IdEstatus = clienteDto.IdEstatus;
                cliente.IdEstatusCrediticio = clienteDto.IdEstatusCrediticio;
                cliente.Estatus = null;
                cliente.EstatusCrediticio = null;
                cliente.Direccion = _mapper.Map<Direccion>(clienteDto.Direccion);
                await this._unitOfWork.Clientes.Update(cliente);
                await this._unitOfWork.SavechangesAsync();
                await this._unitOfWork.Direcciones.Update(cliente.Direccion);
                await this._unitOfWork.SavechangesAsync();
                response.Data = _mapper.Map<ClienteDto>(cliente);
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

        // POST: api/Clientes
        [HttpPost]
        [Authorize(Roles = "Prestador")]
        public async Task<ActionResult<Cliente>> Post([FromBody] AddClienteDto clienteDto)
        {
            var response = new ApiResponse<ClienteDto>();
            try
            {
                var cliente = _mapper.Map<Cliente>(clienteDto);
                cliente.IdEstatus = (int) EstatusClientes.Activo;
                cliente.IdEstatusCrediticio =  (int) EstatuCrediticioCliente.Libre;
                await this._unitOfWork.Direcciones.Add(cliente.Direccion);
                await this._unitOfWork.SavechangesAsync();
                cliente.IdDireccion = cliente.Direccion.Id;
                await this._unitOfWork.Clientes.Add(cliente);
                await this._unitOfWork.SavechangesAsync();
                response.Data = _mapper.Map<ClienteDto>(cliente);
                response.StatusCode = StatusCodes.Status201Created;
            }
            catch (Exception)
            {
                response.Message = "Ocurio un error al obtener los datos!";
                response.Succeeded = false;
                response.StatusCode = StatusCodes.Status400BadRequest;
                return BadRequest(response);
            }

            return Created("api/Clientes", response);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Prestador")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new ApiResponse<ClienteDto>();
            try
            {
                var cliente = await this._unitOfWork.Clientes.GetById(id);
                if (cliente is null)
                {
                    response.Message = "No se encontro el cliente!";
                    response.Succeeded = false;
                    response.StatusCode = StatusCodes.Status404NotFound;
                    return BadRequest(response);
                }
                await this._unitOfWork.Clientes.Delete(cliente);
                await this._unitOfWork.SavechangesAsync();
                await this._unitOfWork.Direcciones.Delete(cliente.Direccion);
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