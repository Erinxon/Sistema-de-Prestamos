using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Prestamos.Core.Entities;
using Prestamos.Infrastructure.ApiResponse;
using Prestamos.Infrastructure.Dtos.AuthDtos;
using Prestamos.Infrastructure.Dtos.EnumsDtos;
using Prestamos.Infrastructure.Implementations;
using Prestamos.Infrastructure.Interfaces;
using Prestamos.Infrastructure.Tools;
using System.Threading.Tasks;

namespace Prestamos.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController : PrestamoControllerBase
    {
        private readonly IConfiguration config;

        public AuthController(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config) : base(unitOfWork, mapper)
        {
            this.config = config;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<UserResponse>>> Login([FromBody] LoginDto login)
        {
            var response = new ApiResponse<UserResponse>();
            try
            {
                var usuario = await this._unitOfWork.Auth
                    .Login(login.Email, login.Password.ToEncryptedPassword());
                if (usuario is null)
                {
                    response.Succeeded = false;
                    response.Message = "Usuario o Contraseña incorrecta";
                    response.StatusCode = StatusCodes.Status404NotFound;
                    return NotFound(response);
                }
                var userResponse = new UserResponse(usuario)
                {
                    Estatus = _mapper.Map<EstatusDto>(usuario.Estatus),
                    Rol = _mapper.Map<RolDto>(usuario.Rol),
                    Token = GenerateJWT.Generate(usuario, this.config)
                };
                response.Data = userResponse;
                response.StatusCode = StatusCodes.Status200OK;
            }
            catch (System.Exception)
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
