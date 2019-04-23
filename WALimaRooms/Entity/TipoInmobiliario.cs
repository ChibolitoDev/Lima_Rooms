using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class TipoInmobiliario
    {
        [DisplayName("Id")]
        public int id { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }

    }
}
