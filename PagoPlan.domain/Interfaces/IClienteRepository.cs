using PagoPlan.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PagoPlan.Core.Interfaces
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> ObtenerClientes();
        Cliente ObtenerCliente(int id);
        IEnumerable<Plan> ClientePlanes(int id);
        void AgregarCliente(Cliente cliente);
        void BorrarCliente(Cliente cliente);
        bool Guardar();
    }
}
