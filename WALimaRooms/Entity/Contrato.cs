using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Contrato
    {
        [DisplayName("Cliente")]
        public Cliente cliente { get; set; }
        [DisplayName("Inmobiliario")]
        public Inmobiliario Inmobiliario { get; set; }

        [DisplayName("Id. Contrato")]
        public int ContratoId { get; set; }

        [Required]
        [DisplayName("Fecha Inicio")]
        public string fechaInicio { get; set; }

        [Required]
        [DisplayName("Fecha Fin")]
        public string fechaFin { get; set; }

        [Required]
        [DisplayName("Fecha Pago")]
        public string FechaPago { get; set; }

        [Required]
        [DisplayName("Costo Alquiler")]
        public string Costo { get; set; }
    }
}
