using PagoPlan.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PagoPlan.Core.Interfaces
{
    public interface IPlanPagoRepository
    {
        IEnumerable<Plan> ObtenerPlanesPago();
        IEnumerable<Plan> PlanesCliente(int idCliente);
        Plan ObtenerPlan(int id);
        void NuevoPlan(Plan plan);
        void ActualizarPlan(Plan plan);
        void EliminarPlan(Plan plan);
        IEnumerable<Cuota> ObtenerCuotasPlan(int planId);
        Cuota ObtenerCuota(int planid, int cuotaId);
        bool PlanPagoExiste(int id);


        //agregar cuotas es llamado al crear plan
        void AgregarCuotas(int planId, int cant);
        Cuota ActualizarCuota(Cuota cuota);
        //si el cliente quiere pagar en mas cuotas luego de creado el plan
        //se cancela plan y se crea nuevo
        void EliminarCuota(int id);
        
        void CancelarTotalPlan(int planId);

        bool Guardar();

            

    }
}
