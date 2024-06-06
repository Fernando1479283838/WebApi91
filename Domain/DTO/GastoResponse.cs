using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class GastoResponse
    {
        public string Tipo { get; set; }
        public string Cantidad { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
    }
}
