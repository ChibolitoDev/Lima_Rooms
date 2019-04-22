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
    public class InmobiliariaRepository : IInmobiliariaRepository
    {
        public bool delete(Inmobiliaria t)
        {
            throw new NotImplementedException();
        }

        public List<Inmobiliaria> FindAll()
        {
            var clientes = new List<Inmobiliaria>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Lima_Rooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select * from Inmobiliaria", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var cliente = new Inmobiliaria();
                            cliente = new Inmobiliaria();
                            cliente.id = Convert.ToInt32(dr["id"]);
                            cliente.Nombre = dr["Nombre"].ToString();
                            cliente.Direccion = dr["Direccion"].ToString();
                            cliente.tipoI.id= Convert.ToInt32(dr["TipoInmobiliario_id"]);
                            cliente.Precio = Convert.ToInt32(dr["Precio"]);

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

        public Inmobiliaria FindbyID(int? id)
        {
            Inmobiliaria cliente = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Lima_Rooms"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("select * from Inmobiliaria where id ='" + id + "'", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cliente = new Inmobiliaria();
                            cliente.id = Convert.ToInt32(dr["id"]);
                            cliente.Nombre = dr["Nombre"].ToString();
                            cliente.Direccion = dr["Direccion"].ToString();
                            cliente.tipoI.id = Convert.ToInt32(dr["TipoInmobiliario_id"]);
                            cliente.Precio = Convert.ToInt32(dr["Precio"]);

                        }
                    }
                }


            }
            catch (Exception ex) { throw; }

            return cliente;
        }

        public bool insert(Inmobiliaria t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Lima_Rooms"].ToString()))
                {
                    var query = new SqlCommand("insert into Inmobiliaria values (@Nombre,@Direccion,@TipoInmobiliario_id,@Precio)", con);
                    query.Parameters.AddWithValue("@Nombre", t.Nombre);
                    query.Parameters.AddWithValue("@Direccion", t.Direccion);
                    query.Parameters.AddWithValue("@TipoInmobiliario_id", t.tipoI);
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

        public bool update(Inmobiliaria t)
        {
            throw new NotImplementedException();
        }
    }
}
