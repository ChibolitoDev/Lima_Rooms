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
    public class ContratoService : IContratoService
    {
        private readonly IContratoRepository contratoRepository = new ContratoRepository();
        public bool Delete(int id)
        {
            return contratoRepository.delete(id);
        }

        public List<Contrato> FindAll()
        {
            return contratoRepository.FindAll();
        }

        public Contrato FindById(int? id)
        {
            return contratoRepository.FindbyID(id);
        }

        public bool insert(Contrato t)
        {
            return contratoRepository.insert(t);
        }

        public bool Update(Contrato t)
        {
            return contratoRepository.update(t);
        }
    }
}
