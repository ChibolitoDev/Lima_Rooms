using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Contrato
    {
        Cliente Cliente;
        Inmobiliaria Inmobiliario;

        [DisplayName("Id")]
        public int id { get; set; }

        [DisplayName("FechaInicio")]
        public string FechaI { get; set; }

        [DisplayName("FechaFin")]
        public string FechaF { get; set; }

        [DisplayName("FechaPago")]
        public string FechaPago { get; set; }

        [DisplayName("CostoAlquiler")]
        public string CostoF { get; set; }
    }
}
