using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Inmobiliaria
    {
        [DisplayName("Id")]
        public int id { get; set; }

        Tipo_Inmobiliaria Tipo_Inm;

        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Direccion")]
        public string Direccion { get; set; }

        [DisplayName("Precio")]
        public int Precio { get; set; }

        public Tipo_Inmobiliaria tipoI;
    }
}
