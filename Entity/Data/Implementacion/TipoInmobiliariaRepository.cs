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
    public class TipoInmobiliariaRepository : ITipo_InmobiliariaRepository
    {
        public bool delete(Tipo_Inmobiliaria t)
        {
            throw new NotImplementedException();
        }

        public List<Tipo_Inmobiliaria> FindAll()
        {
            var clientes = new List<Tipo_Inmobiliaria>();
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
                            var cliente = new Tipo_Inmobiliaria();
                            cliente = new Tipo_Inmobiliaria();
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

        public Tipo_Inmobiliaria FindbyID(int? id)
        {

            Tipo_Inmobiliaria cliente = null;
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
                            cliente = new Tipo_Inmobiliaria();
                            cliente.id = Convert.ToInt32(dr["id"]);
                            cliente.Nombre = dr["Nombre"].ToString();

                        }
                    }
                }


            }
            catch (Exception ex) { throw; }

            return cliente;
        }

        public bool insert(Tipo_Inmobiliaria t)
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

        public bool update(Tipo_Inmobiliaria t)
        {
            throw new NotImplementedException();
        }
    }
}
