using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PagoPlan.Core.Entities
{
    public class Plan
    {
        [Key]
        public int PlanPagoId { get; set; }
        [Required]
        public int CantCuotas { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalPlan { get; set; }
        public DateTime FechaVenta { get; set; }
        [Required]
        [MaxLength(200)]
        public string Descripcion { get; set; }
        [MaxLength(200)]
        public double Interes { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public ICollection<Cuota> Cuotas { get; set; } = new List<Cuota>();
    }
}
