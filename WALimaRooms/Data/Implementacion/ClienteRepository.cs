using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data.Implementacion
{
    public class ClienteRepository : IClienteRepository
    {
        public bool delete(Cliente t)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> FindAll()
        {
            var clientes = new List<Cliente>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString())) {
                    con.Open();
                    var query = new SqlCommand("select* from Cliente", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var cliente = new Cliente();
                            cliente.ClienteId = Convert.ToInt32(dr[0]);
                            cliente.NombreCliente = dr["NombreCliente"].ToString();
                            cliente.apellPaterno = dr["apellPaterno"].ToString();
                            cliente.apellMaterno = dr["apellMaterno"].ToString();
                            cliente.Nacionalidad = dr["Nacionalidad"].ToString();
                            cliente.Telefono = dr["Phone"].ToString();
                            cliente.Correo = dr["email"].ToString();

                            clientes.Add(cliente);
                        }
                    }
                    con.Close();
                }
            }catch(Exception e)
            {
                throw;
            }
            return clientes;            
        }

        public Cliente FindbyID(int? id)
        {
            Cliente cliente = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Lima_Rooms"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("select * from Cliente where ClienteId='" + id + "'", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cliente = new Cliente();
                            cliente.ClienteId = Convert.ToInt32(dr[0]);
                            cliente.NombreCliente = dr["NombreCliente"].ToString();
                            cliente.apellPaterno = dr["apellPaterno"].ToString();
                            cliente.apellMaterno = dr["apellMaterno"].ToString();
                            cliente.Nacionalidad = dr["Nacionalidad"].ToString();
                            cliente.Telefono = dr["Phone"].ToString();
                            cliente.Correo = dr["email"].ToString();
                        }
                    }
                }


            }
            catch (Exception ex) { throw; }

            return cliente;
        }

        public bool insert(Cliente t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    var query = new SqlCommand("insert into Cliente values (@NombreCliente," +
                        "                        @apellPaterno, @apellMaterno, @Nacionalidad, @Phone," +
                        "                        @email)", con);
                    query.Parameters.AddWithValue("@NombreCliente", t.NombreCliente);
                    query.Parameters.AddWithValue("@apellPaterno", t.apellPaterno);
                    query.Parameters.AddWithValue("@apellMaterno", t.apellPaterno);
                    query.Parameters.AddWithValue("@Nacionalidad", t.Nacionalidad);
                    query.Parameters.AddWithValue("@Phone", t.Telefono);
                    query.Parameters.AddWithValue("@email", t.Correo);
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

        public bool update(Cliente t)
        {
            throw new NotImplementedException();
        }
    }
}
