using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Implementaciones
{
    public class TipoInmobiliarioRepository : ITipoInmobiliarioRepository
    {
        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TipoInmobiliario> FindAll()
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

        public TipoInmobiliario FindbyID(int? id)
        {

            TipoInmobiliario tipoInmobiliario = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("select * from TipoInmobiliario where TipoInmobiliarioId='" + id + "'", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            tipoInmobiliario = new TipoInmobiliario();
                            tipoInmobiliario.TipoInmobiliarioId = Convert.ToInt32(dr[0]);
                            tipoInmobiliario.NombreTipoInmobiliario = dr["NombreTipoInmobiliario"].ToString();

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return tipoInmobiliario;
        }

        public bool insert(TipoInmobiliario t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    var query = new SqlCommand("insert into TipoInmobiliario values (@Nombre)", con);
                    query.Parameters.AddWithValue("@Nombre", t.NombreTipoInmobiliario);
                    query.ExecuteNonQuery();
                    rpta = true;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return rpta;
        }

        public bool update(TipoInmobiliario t)
        {
            throw new NotImplementedException();
        }
    }
}
