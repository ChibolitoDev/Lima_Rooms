using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Persona
    {
        [DisplayName("Id")]
        public int id { get; set; }

        [DisplayName("Nombre")]
        public string nombre { get; set; }

        [DisplayName("Apellido Paterno")]
        public string ApellidoPat { get; set; }

        [DisplayName("Apellido Materno")]
        public string ApellidoMat { get; set; }

        [DisplayName("Phone")]
        public string Telefono { get; set; }

        [DisplayName("email")]
        public string Correo { get; set; }
    }
}
