using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Callcenter.Models
{
    public class Clases
    {
    }

    public class consulta
    {
        public string cedula { get; set; }
        public string nombreCompleto { get; set; }
        public string fechaPago { get; set; }
        public decimal monto { get; set; }
    }
}