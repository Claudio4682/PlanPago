using System;
using System.Collections.Generic;
using System.Text;

namespace PagoPlan.Core.Dtos.PlanPagoDtos
{
    public class PlanCreateDto
    {
        public int CantCuotas { get; set; }
        public decimal TotalPlan { get; set; }
        public DateTime FechaVenta { get; set; }
        public string Descripcion { get; set; }
        public double Interes { get; set; }
        public int ClienteId { get; set; }
    }
}
