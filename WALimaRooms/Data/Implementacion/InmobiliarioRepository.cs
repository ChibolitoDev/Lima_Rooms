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
    public class InmobiliarioRepository : IInmobiliarioRepository
    {     
        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Inmobiliario> FindAll()
        {
            var inmobiliarios = new List<Inmobiliario>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select * from Inmobiliario", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var inmobiliario = new Inmobiliario();
                            inmobiliario.InmobiliarioId = Convert.ToInt32(dr["id"]);
                            inmobiliario.NombreInmobiliario = dr["NombreInmobiliario"].ToString();
                            inmobiliario.DireccionInmobiliario = dr["DireccionInmobiliario"].ToString();
                            inmobiliario.tipoInmobiliario.NombreTipoInmobiliario = dr["TipoInmobiliario"].ToString();
                            inmobiliario.Precio = Convert.ToInt32(dr["Precio"]);

                            inmobiliarios.Add(inmobiliario);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return inmobiliarios;
        }

        public Inmobiliario FindbyID(int? id)
        {
            Inmobiliario inmobiliario = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("select * from Inmobiliario where id ='" + id + "'", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            inmobiliario = new Inmobiliario();
                            inmobiliario.InmobiliarioId = Convert.ToInt32(dr["id"]);
                            inmobiliario.NombreInmobiliario = dr["NombreInmobiliario"].ToString();
                            inmobiliario.DireccionInmobiliario = dr["DireccionInmobiliario"].ToString();
                            inmobiliario.tipoInmobiliario.NombreTipoInmobiliario = dr["TipoInmobiliario"].ToString();
                            inmobiliario.Precio = Convert.ToInt32(dr["Precio"]);

                        }
                    }
                }


            }
            catch (Exception ex) { throw; }

            return inmobiliario;
        }

        public bool insert(Inmobiliario t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    var query = new SqlCommand("insert into Inmobiliario values (@NombreInmobiliario" +
                        "                       ,@DireccionInmobiliario,@TipoInmobiliario_id,@Precio)", con);
                    query.Parameters.AddWithValue("@NombreInmobiliario", t.NombreInmobiliario);
                    query.Parameters.AddWithValue("@Direccion", t.DireccionInmobiliario);
                    query.Parameters.AddWithValue("@TipoInmobiliario_id", t.tipoInmobiliario.TipoInmobiliarioId);
                    query.Parameters.AddWithValue("@Precio", t.Precio);


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

        public bool update(Inmobiliario t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("update Inmobiliario set NombreInmobiliario=@NombreInmobiliario," +
                        "                       DireccionInmobiliario=@DireccionInmobiliario," +
                        "                       TipoInmobiliario_id=@TipoInmobiliario_id,Precio=@Precio" +
                        "                       where InmobiliarioId=@InmobiliarioId", con);

                    query.Parameters.AddWithValue("@InmobiliarioId", t.InmobiliarioId);
                    query.Parameters.AddWithValue("@NombreInmobiliario", t.NombreInmobiliario);
                    query.Parameters.AddWithValue("@TipoInmobiliario_id", t.tipoInmobiliario.TipoInmobiliarioId);
                    query.Parameters.AddWithValue("@Precio", t.Precio);

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
