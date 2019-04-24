using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data.Implementaciones
{
    public class ContratoRepository : IContratoRepository
    {
        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contrato> FindAll()
        {
            var contratos = new List<Contrato>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select * from Contrato", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var contrato = new Contrato();
                            contrato.ContratoId = Convert.ToInt32(dr["ContratoId"]);
                            contrato.Inmobiliario.NombreInmobiliario = dr["NombreInmobiliario"].ToString();
                            contrato.fechaInicio = Convert.ToDateTime(dr["fechaInicio"]);
                            contrato.fechaFin = Convert.ToDateTime(dr["fechaFin"]);
                            contrato.FechaPago = Convert.ToDateTime(dr["FechaPago"]);
                            contrato.cliente.NombreCliente = dr["NombreCliente"].ToString();
                            contratos.Add(contrato);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return contratos;
        }

        public Contrato FindbyID(int? id)
        {
            Contrato contrato = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("select * from Contrato where id ='" + id + "'", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            contrato = new Contrato();
                            contrato.ContratoId = Convert.ToInt32(dr["ContratoId"]);
                            contrato.Inmobiliario.NombreInmobiliario = dr["NombreInmobiliario"].ToString();
                            contrato.fechaInicio = Convert.ToDateTime(dr["fechaInicio"]);
                            contrato.fechaFin = Convert.ToDateTime(dr["fechaFin"]);
                            contrato.FechaPago = Convert.ToDateTime(dr["FechaPago"]);
                            contrato.cliente.NombreCliente = dr["NombreCliente"].ToString();

                        }
                    }
                }


            }
            catch (Exception ex) { throw; }

            return contrato;
        }

        public bool insert(Contrato t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    var query = new SqlCommand("insert into Contrato values (@Inmobiliario_id," +
                        "       @fechaInicio,@fechaFin,@FechaPago,@Cliente_id)", con);
                    query.Parameters.AddWithValue("Inmobiliario_id", t.Inmobiliario.InmobiliarioId);
                    query.Parameters.AddWithValue("fechaInicio", t.fechaInicio);
                    query.Parameters.AddWithValue("fechaFin", t.fechaFin);
                    query.Parameters.AddWithValue("FechaPago", t.FechaPago);
                    query.Parameters.AddWithValue("Cliente_id", t.cliente.ClienteId);
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

        public bool update(Contrato t)
        {

            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("update Contrato set  Inmobiliario_id=@Inmobiliario_id, " +
                                    "fechaInicio=@fechaInicio,fechaFin=@fechaFin,@FechaPago," +
                                    "Cliente_id=@Cliente_id where ContratoId=@ContratoId", con);

                    query.Parameters.AddWithValue("@ContratoId", t.ContratoId);
                    query.Parameters.AddWithValue("@Inmobiliario_id", t.Inmobiliario.InmobiliarioId);
                    query.Parameters.AddWithValue("@fechaInicio", t.fechaInicio);
                    query.Parameters.AddWithValue("@fechaFin", t.fechaFin);
                    query.Parameters.AddWithValue("@FechaPago", t.FechaPago);
                    query.Parameters.AddWithValue("@Cliente_id", t.cliente.ClienteId);

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
    
