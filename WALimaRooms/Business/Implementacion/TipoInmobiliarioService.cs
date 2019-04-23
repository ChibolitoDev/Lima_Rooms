﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Implementaciones;
using Entity;

namespace Business.Implementacion
{
    public class TipoInmobiliarioService : ITipoInmobiliarioService
    {
        private ITipoInmobiliarioRepository tipoInmobiliario = new TipoInmobiliarioRepository();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TipoInmobiliario> FindAll()
        {
            return tipoInmobiliario.FindAll();
        }

        public TipoInmobiliario FindById(int? id)
        {
            return tipoInmobiliario.FindbyID(id);
        }

        public bool insert(TipoInmobiliario t)
        {
            return tipoInmobiliario.insert(t);
        }

        public bool Update(TipoInmobiliario t)
        {
            return tipoInmobiliario.update(t);
        }
    }
}