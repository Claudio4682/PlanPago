using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagoPlan.Core.Dtos.CuotaDtos;
using PagoPlan.Core.Interfaces;

namespace PlanPago.api.Controllers
{
    [Route("api/planpago/{planId}/cuotas")]
    [ApiController]
    public class CuotasController : ControllerBase
    {
        private readonly IPlanPagoRepository _planesRepo;
        private readonly IMapper _mapper;

        public CuotasController(IPlanPagoRepository planPagoRepository, IMapper mapper)
        {
            _planesRepo = planPagoRepository;
            _mapper = mapper;
        }


        [HttpGet()]
        public ActionResult<IEnumerable<CuotaDto>> GetCuotasPlan(int planId)
        {
            var cuotasEntity = _planesRepo.ObtenerCuotasPlan(planId);
            if (cuotasEntity == null)
                return NotFound();

            var cuotasDto = _mapper.Map<IEnumerable<CuotaDto>>(cuotasEntity);
            return Ok(cuotasDto);
        }

        [HttpGet("{id}")]
        public ActionResult<CuotaDto> GetCuota(int planId, int cuotaId)
        {
            if (!_planesRepo.PlanPagoExiste(planId))
                return NotFound();

            var cuotaEntity = _planesRepo.ObtenerCuota(planId, cuotaId);
            if (cuotaEntity == null)
                return NotFound();

            var cuotaDto = _mapper.Map<CuotaDto>(cuotaEntity);
            return Ok(cuotaDto);
        }


    }
}
