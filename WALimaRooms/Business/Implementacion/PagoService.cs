using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Implementaciones;
using Entity;

namespace Business.Implementacion
{
    public class PagoService : IPagoService
    {
        private IPagoRepository pagoRepository = new PagoRepository();
        public bool Delete(int id)
        {
            return pagoRepository.delete(id);
        }

        public List<Pago> FindAll()
        {
            return pagoRepository.FindAll();
        }

        public Pago FindById(int? id)
        {
            return pagoRepository.FindbyID(id);
        }

        public bool insert(Pago t)
        {
            return pagoRepository.insert(t);
        }

        public bool Update(Pago t)
        {
            return pagoRepository.update(t);
        }
    }
}
