using PagoPlan.Core.Enumeraciones;
using System;
using System.Collections.Generic;
using System.Text;

namespace PagoPlan.Core.Dtos.CuotaDtos
{
    public class CuotaDto
    {
        public int CuotaId { get; set; }
        public decimal ImporteCuota { get; set; }
        public EstadoCuota EstadoCuota { get; set; }
        public int PlanPagoId { get; set; }
    }
}
