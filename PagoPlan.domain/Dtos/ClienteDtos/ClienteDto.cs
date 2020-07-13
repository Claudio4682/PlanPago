using System;
using System.Collections.Generic;
using System.Text;

namespace PagoPlan.Core.Dtos.ClienteDtos
{
    public class ClienteDto
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Descripcion { get; set; }
    }
}
