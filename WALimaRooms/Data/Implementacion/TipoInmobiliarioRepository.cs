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
        public bool delete(TipoInmobiliario t)
        {
            throw new NotImplementedException();
        }

        public List<TipoInmobiliario> FindAll()
        {
            var clientes = new List<TipoInmobiliario>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Lima_Rooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select * from Tipo_Inmobiliaria", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var cliente = new TipoInmobiliario();
                            cliente = new TipoInmobiliario();
                            cliente.id = Convert.ToInt32(dr["PersonaID"]);
                            cliente.Nombre = dr["Nombre"].ToString();

                            clientes.Add(cliente);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return clientes;
        }

        public TipoInmobiliario FindbyID(int? id)
        {

            TipoInmobiliario cliente = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Lima_Rooms"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("select * from Tipo_Inmobiliaria where id='" + id + "'", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cliente = new TipoInmobiliario();
                            cliente.id = Convert.ToInt32(dr["id"]);
                            cliente.Nombre = dr["Nombre"].ToString();

                        }
                    }
                }


            }
            catch (Exception ex) { throw; }

            return cliente;
        }

        public bool insert(TipoInmobiliario t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Lima_Rooms"].ToString()))
                {
                    var query = new SqlCommand("insert into Tipo_Inmobiliaria values (@Nombre)", con);
                    query.Parameters.AddWithValue("@Nombre", t.Nombre);
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
