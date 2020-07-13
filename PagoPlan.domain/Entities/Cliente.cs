using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PagoPlan.Core.Entities
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(50)]
        public string Apellido { get; set; }
        [Required]
        public string Telefono { get; set; }
        public string Email { get; set; }
        [MaxLength(200)]
        public string Descripcion { get; set; }
        public ICollection<Plan> Cuotas { get; set; } = new List<Plan>();
    }
}
