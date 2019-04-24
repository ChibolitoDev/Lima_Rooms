using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data.Implementaciones
{
    public class PagoRepository : IPagoRepository
    {
        public bool delete(Pago t)
        {
            throw new NotImplementedException();
        }

        public List<Pago> FindAll()
        {
            var tipoInmobiliarios = new List<TipoInmobiliario>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select * from TipoInmobiliario", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var tipoInmobiliario = new TipoInmobiliario();
                            tipoInmobiliario = new TipoInmobiliario();
                            tipoInmobiliario.TipoInmobiliarioId = Convert.ToInt32(dr[0]);
                            tipoInmobiliario.NombreTipoInmobiliario = dr["NombreTipoInmobilario"].ToString();

                            tipoInmobiliarios.Add(tipoInmobiliario);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return tipoInmobiliarios;
        }

        public Pago FindbyID(int? id)
        {
            throw new NotImplementedException();
        }

        public bool insert(Pago t)
        {
            throw new NotImplementedException();
        }

        public bool update(Pago t)
        {
            throw new NotImplementedException();
        }
    }
}
