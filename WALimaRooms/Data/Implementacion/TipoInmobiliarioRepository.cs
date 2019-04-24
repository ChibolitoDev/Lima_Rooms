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
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("delete from TipoInmobiliario where TipoInmobiliarioId='" + id + "'", con);
                    query.Parameters.AddWithValue("@ClienteId", Convert.ToInt32(id));
                    query.ExecuteNonQuery();
                    rpta = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return rpta;
        }

        public List<TipoInmobiliario> FindAll()
        {
            var tipoInmobiliarios = new List<TipoInmobiliario>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select * from TipoInmobilario", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var tipo = new TipoInmobiliario();
                            tipo.TipoInmobiliarioId = Convert.ToInt32(dr[0]);
                            tipo.NombreTipoInmobiliario = dr["NombreTipoInmobilario"].ToString();

                            tipoInmobiliarios.Add(tipo);
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
                    var query = new SqlCommand("select * from TipoInmobilario where TipoInmobiliarioId='" + id + "'", con);

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
                    con.Open();
                    var query = new SqlCommand("insert into TipoInmobilario values (@TipoInmobiliarioId,@NombreTipoInmobiliario)", con);
                    query.Parameters.AddWithValue("@TipoInmobiliarioId", t.TipoInmobiliarioId);
                    query.Parameters.AddWithValue("@NombreTipoInmobiliario", t.NombreTipoInmobiliario);
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
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("update TipoInmobilario set  " +
                        "           NombreTipoInmobiliario=@NombreTipoInmobiliario " +
                        "           where TipoInmobiliarioId=@CTipoInmobiliarioId", con);

                    query.Parameters.AddWithValue("@CTipoInmobiliarioId", t.TipoInmobiliarioId);
                    query.Parameters.AddWithValue("@NombreTipoInmobiliario", t.NombreTipoInmobiliario);

                    query.ExecuteNonQuery();

                    rpta = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return rpta;
        }
    }
}
