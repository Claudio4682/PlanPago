using PagoPlan.Core.Entities;
using PagoPlan.Core.Enumeraciones;
using PagoPlan.Core.Interfaces;
using PlanPago.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanPago.Infrastructure.Repositories
{
    public class PlanPagoRepository : IPlanPagoRepository
    {
        private readonly PlanPagoContext _context;

        public PlanPagoRepository(PlanPagoContext context)
        {
            _context = context;
        }

        public IEnumerable<Plan> ObtenerPlanesPago()
        {
            return _context.PlanesPagos.ToList();
        }

        public IEnumerable<Plan> PlanesCliente(int idCliente)
        {
            return _context.PlanesPagos.Where(p => p.ClienteId == idCliente);
        }

        public Plan ObtenerPlan(int id)
        {
            return _context.PlanesPagos.Where(p => p.PlanPagoId == id).FirstOrDefault();
        }

        public void NuevoPlan(Plan plan)
        {
            if (plan == null)
                throw new ArgumentNullException(nameof(plan));

            _context.PlanesPagos.Add(plan);
        }

        public void ActualizarPlan(Plan plan)
        {
            //no se implementa xq al estar trabajando con entity framework, este se encarga de monitorear los cambios de las entidades
        }

        public void EliminarPlan(Plan plan)
        {
            if (plan == null)
                throw new ArgumentNullException(nameof(plan));

            _context.PlanesPagos.Remove(plan);
        }

        public IEnumerable<Cuota> ObtenerCuotasPlan(int planId)
        {
            return _context.Cuotas.Where(c => c.PlanPagoId == planId).ToList();
            //.OrderBy(c => c.CuotaId)
            //.ToList();
        }

        public Cuota ObtenerCuota(int planId, int cuotaId)
        {
            //validar validos ids

            return _context.Cuotas.Where(c => c.CuotaId == cuotaId && c.PlanPagoId == c.PlanPagoId)
                                  .FirstOrDefault();
        }





        public Cuota ActualizarCuota(Cuota cuota)
        {
            var cuotaAGuardar = _context.Cuotas.Where(c => c.CuotaId == cuota.CuotaId && c.PlanPagoId == cuota.PlanPagoId)
                                       .FirstOrDefault();

            cuotaAGuardar.EstadoCuota = cuota.EstadoCuota;
            return cuota;
        }

        public void AgregarCuotas(int planId, int cant)
        {
            throw new NotImplementedException();
        }

        public void CancelarTotalPlan(int planId)
        {
            throw new NotImplementedException();
        }

        public void EliminarPlan(int planId)
        {
            throw new NotImplementedException();
        }

       

        public bool Guardar()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Cuota> GetCuotas()
        {
            return _context.Cuotas.ToList();
        }

        public void EliminarCuota(int id)
        {
            throw new NotImplementedException();
        }

        public bool PlanPagoExiste(int id)
        {
            if (id <= 0)
                throw new ArgumentException(nameof(id));

            return _context.PlanesPagos.Any(p => p.PlanPagoId == id);
        }


    }
}
