using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Prestamos.Infrastructure.Interfaces;

namespace Prestamos.Api.Controllers
{
    public class PrestamoControllerBase : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public PrestamoControllerBase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
    }
}
