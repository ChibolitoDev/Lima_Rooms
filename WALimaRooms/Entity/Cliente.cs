using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Cliente : Persona
    {

        public Guardia guardia { get; set; }

        [DisplayName("Nacionalidad")]
        public string Nacionalidad { get; set; }

        [DisplayName("Relacion_Guardia")]
        public string RelacionC { get; set; }
    }
}
