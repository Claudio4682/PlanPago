using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagoPlan.Core.Dtos.ClienteDtos;
using PagoPlan.Core.Dtos.PlanPagoDtos;
using PagoPlan.Core.Entities;
using PagoPlan.Core.Interfaces;

namespace PlanPago.api.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clientesRepo;
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clientesRepo = clienteRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClienteDto>> GetClientes()
        {
            var clientesEntity = _clientesRepo.ObtenerClientes();
            var clientesDto = _mapper.Map<IEnumerable<ClienteDto>>(clientesEntity);
            return Ok(clientesDto);

        }

        [HttpGet("{id}", Name = "GetCliente")]
        public IActionResult GetCliente(int id)
        {
            var clienteEntity = _clientesRepo.ObtenerCliente(id);
            if (clienteEntity == null)
                return NotFound();

            var clienteDto = _mapper.Map<ClienteDto>(clienteEntity);
            return Ok(clienteDto);

        }

        [HttpGet("{id}/planes")]
        public ActionResult<IEnumerable<PlanReadDto>> GetPlanesCliente(int id)
        {
            var planesEntity = _clientesRepo.ClientePlanes(id);
            if (planesEntity == null)
                return NotFound();

            var planesDto = _mapper.Map<IEnumerable<PlanReadDto>>(planesEntity);
            return Ok(planesDto);
        }

        [HttpPost]
        public ActionResult<ClienteDto> AddCliente(ClienteCreateDto cliente)
        {
            var clienteEntity = _mapper.Map<Cliente>(cliente);
            _clientesRepo.AgregarCliente(clienteEntity);
            _clientesRepo.Guardar();

            var clienteGuardado = _mapper.Map<ClienteDto>(clienteEntity);

            return CreatedAtRoute("GetCliente", new { id = clienteGuardado.ClienteId }, clienteGuardado);
        }

        [HttpPut("{id}")]
        public ActionResult<ClienteDto> UpdateCliente(int id, ClienteCreateDto cliente)
        {
            var clienteEntity = _clientesRepo.ObtenerCliente(id);
            if (clienteEntity == null)
                return NotFound();

            //mapeo distinto xq en este caso ambas entidades tienen datos, voy desde cliente pasado a un cliente ya existente
            _mapper.Map(cliente, clienteEntity);
            _clientesRepo.Guardar();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult BorrarCliente(int id)
        {
            var clienteEntity = _clientesRepo.ObtenerCliente(id);
            if (clienteEntity == null)
                return NotFound();

            _clientesRepo.BorrarCliente(clienteEntity);
            _clientesRepo.Guardar();

            return NoContent();
        }
    }
}
