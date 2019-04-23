using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Pago
    {
        Contrato Contrato;

        [DisplayName("IdPago")]
        public int Id { get; set; }

        [DisplayName("Num_Transaccion")]
        public string NumeroTrans { get; set; }

        
    }
}
