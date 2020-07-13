using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PagoPlan.Core.Dtos.CuotaDtos;
using PagoPlan.Core.Dtos.PlanPagoDtos;
using PagoPlan.Core.Entities;
using PagoPlan.Core.Interfaces;
using PlanPago.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanPago.api.Controllers
{
    [ApiController]
    [Route("api/planpago")]
    public class PlanPagoController : ControllerBase
    {
        private readonly IPlanPagoRepository _planesRepo;
        private readonly IMapper _mapper;

        public PlanPagoController(IPlanPagoRepository planPagoRepository, IMapper mapper)
        {
            _planesRepo = planPagoRepository;
            _mapper = mapper;
        }
        
        
        [HttpGet]
        public ActionResult<IEnumerable<PlanReadDto>> GetPlanes()
        {
            var planesRepo = _planesRepo.ObtenerPlanesPago();
            var planesDto = _mapper.Map<IEnumerable<PlanReadDto>>(planesRepo);
            return Ok(planesDto);
                
        }

        [HttpGet("{id}", Name = "GetPlan")]
        public IActionResult GetPlan(int id)
        {
            var planesEntity = _planesRepo.ObtenerPlan(id);
            if (planesEntity == null)
                return NotFound();

            var planesDto = _mapper.Map<IEnumerable<PlanReadDto>>(planesEntity);
            return Ok(planesDto);

        }
        /***

        [HttpGet("{id}/cuotas")]
        public ActionResult<IEnumerable<CuotaDto>> GetCuotasPlan(int id)
        {
            var cuotasEntity = _planesRepo.ObtenerCuotasPlan(id);
            if (cuotasEntity == null)
                return NotFound();

            var cuotasDto = _mapper.Map<IEnumerable<CuotaDto>>(cuotasEntity);
            return Ok(cuotasDto);
        }
        ***/

        [HttpPost]
        public ActionResult<PlanReadDto> AddCliente(PlanCreateDto plan)
        {
            var planEntity = _mapper.Map<Plan>(plan);
            _planesRepo.NuevoPlan(planEntity);
            _planesRepo.Guardar();

            var planGuardado = _mapper.Map<PlanReadDto>(planEntity);

            return CreatedAtRoute("GetPlan", new { id = planGuardado.ClienteId }, planGuardado);
        }

        [HttpPut("{id}")]
        public ActionResult<PlanReadDto> ModificarPlanPago(int id, PlanCreateDto plan)
        {
            var planEntity = _planesRepo.ObtenerPlan(id);
            if (planEntity == null)
                return NotFound();

            _mapper.Map(plan, planEntity);
            _planesRepo.Guardar();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult BorrarPlanPago(int id)
        {
            var planEntity = _planesRepo.ObtenerPlan(id);
            if (planEntity == null)
                return NotFound();

            _planesRepo.EliminarPlan(planEntity);
            _planesRepo.Guardar();

            return NoContent();
        }

        




    }
}
