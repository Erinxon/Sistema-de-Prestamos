using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prestamos.Infrastructure.ApiResponse;
using Prestamos.Infrastructure.Dtos.Dashboard;
using Prestamos.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prestamos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DashboardController : PrestamoControllerBase
    {
        public DashboardController(IUnitOfWork unitOfWork, IMapper mapper): base(unitOfWork, mapper)
        {

        }

        // GET: api/Dashboard
        [HttpGet]
        public async Task<ActionResult<ApiResponse<DashboardDto>>> GetAll()
        {
            var response = new ApiResponse<DashboardDto>();
            try
            {
                var dashboardDto = new DashboardDto
                {
                    CantidadClientes = await this._unitOfWork.Clientes.GetCount(),
                    CantidadPrestamos = await this._unitOfWork.Prestamos.GetCount(),
                    CantidadPrestamosPagados = await this._unitOfWork.Prestamos.GetCountPrestamosPagado(),
                    CantidadPrestamosPendientes = await this._unitOfWork.Prestamos.GetCountPrestamosAtrasado()
                };
                response.Data = dashboardDto;
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
