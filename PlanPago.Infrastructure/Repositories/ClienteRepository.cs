using PagoPlan.Core.Entities;
using PagoPlan.Core.Interfaces;
using PlanPago.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanPago.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly PlanPagoContext _context;

        public ClienteRepository(PlanPagoContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> ObtenerClientes()
        {
            return _context.Clientes.ToList();
        }
        public Cliente ObtenerCliente(int id)
        {
            return _context.Clientes.Where(c => c.ClienteId == id).FirstOrDefault();
        }

        public IEnumerable<Plan> ClientePlanes(int idCliente)
        {
            return _context.PlanesPagos.Where(p => p.ClienteId == idCliente);
        }

        public void AgregarCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            _context.Clientes.Add(cliente);
        }

        public void BorrarCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente));

            _context.Clientes.Remove(cliente);
        }

        public bool Guardar()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}
