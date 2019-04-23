using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

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
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Lima_Rooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select * from bd_cliente", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var cliente = new Cliente();
                            cliente = new Cliente();
                            cliente.id = Convert.ToInt32(dr["PersonaID"]);
                            cliente.nombre = dr["Nombre"].ToString();
                            cliente.ApellidoMat = dr["ApellPMaterno"].ToString();
                            cliente.ApellidoPat = dr["ApellPaterrno"].ToString();
                            cliente.Nacionalidad = dr["Nacionalidad"].ToString();
                            cliente.guardia.nombre = dr["Nombre_Guardia"].ToString();
                            cliente.RelacionC = dr["RelacionC"].ToString();
                            cliente.Telefono = dr["Telefono"].ToString();
                            cliente.Correo = dr["Email"].ToString();
                            
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

        public Cliente FindbyID(int? id)
        {
            Cliente cliente = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Lima_Rooms"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("select * from bd_cliente where IdCliente='" + id + "'", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cliente = new Cliente();
                            cliente.id = Convert.ToInt32(dr["PersonaID"]);
                            cliente.nombre = dr["Nombre"].ToString();
                            cliente.ApellidoMat = dr["ApellPMaterno"].ToString();
                            cliente.ApellidoPat = dr["ApellPaterrno"].ToString();
                            cliente.Nacionalidad = dr["Nacionalidad"].ToString();
                            cliente.guardia.nombre = dr["Nombre_Guardia"].ToString();
                            cliente.RelacionC = dr["RelacionC"].ToString();
                            cliente.Telefono = dr["Telefono"].ToString();
                            cliente.Correo = dr["Email"].ToString();

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
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Lima_Rooms"].ToString()))
                {
                    var query = new SqlCommand("insert into Cliente values (@Nombre,@ApellidoPat,@ApellidoMat ,@Nacionalidad,@Phone,@Email,@GuardiaId,Relacion_guardia)", con);
                    query.Parameters.AddWithValue("@Nombre", t.nombre);
                    query.Parameters.AddWithValue("@ApellidoPat", t.ApellidoPat);
                    query.Parameters.AddWithValue("@ApellidoMat", t.ApellidoMat);
                    query.Parameters.AddWithValue("@Nacionalidad", t.Nacionalidad);
                    query.Parameters.AddWithValue("@Phone", t.Telefono);
                    query.Parameters.AddWithValue("@Email", t.Correo);
                    query.Parameters.AddWithValue("Guardia_id", t.guardia);
                    query.Parameters.AddWithValue("Relacion_Guardia", t.RelacionC);


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
    

