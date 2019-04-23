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
    public class InmobiliarioService : IImboliarioService
    {
        private IInmobiliarioRepository inmobiliarioRepository = new InmobiliarioRepository();
        private ITipoInmobiliarioRepository tipoInmobiliarioRepository = new TipoInmobiliarioRepository();
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Inmobiliario> FindAll()
        {
            return inmobiliarioRepository.FindAll();
        }

        public Inmobiliario FindById(int? id)
        {
            return inmobiliarioRepository.FindbyID(id);
        }

        public bool insert(Inmobiliario t)
        {
            TipoInmobiliario tipoInmobiliario = tipoInmobiliarioRepository.FindbyID(t.tipoI.id);
            t.tipoI = tipoInmobiliario;
            return inmobiliarioRepository.insert(t);
        }

        public bool Update(Inmobiliario t)
        {
            return inmobiliarioRepository.update(t);
        }
    }
}
