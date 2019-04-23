using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Inmobiliario
    {
        [DisplayName("Id")]
        public int id { get; set; }

        TipoInmobiliario Tipo_Inm;

        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Direccion")]
        public string Direccion { get; set; }

        [DisplayName("Precio")]
        public int Precio { get; set; }

        public TipoInmobiliario tipoI;
    }
}
