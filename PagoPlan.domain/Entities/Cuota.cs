using PagoPlan.Core.Enumeraciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PagoPlan.Core.Entities
{
    public class Cuota
    {
        [Key]
        public int CuotaId { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ImporteCuota { get; set; }
        public EstadoCuota EstadoCuota { get; set; }

        //esto establece la relación entre tablas
        [ForeignKey("PlanPagoId")]
        public Plan PlanPago { get; set; }
        public int PlanPagoId { get; set; }

    }
}
