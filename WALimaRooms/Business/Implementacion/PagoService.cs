using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Implementaciones;
using Entity;

namespace Business.Implementacion
{
    public class PagoService : IPagoService
    {
        private IPagoRepository pagoRepository = new PagoRepository();
        public bool Delete(int id)
        {
            return pagoRepository.delete(id);
        }

        public List<Pago> FindAll()
        {
            var pagos = new List<Pago>();
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("select * from Pago", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var pago = new Pago();
                            pago.PagoId = Convert.ToInt32(dr[0]);
                            pago.NroTransaccion = dr["NroTrasaccion"].ToString();
                            pago.FechaTransaccion = Convert.ToDateTime(dr["FechaTransaccion"]);
                            pago.Contrato.cliente.NombreCliente = dr[3].ToString();
                            pagos.Add(pago);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return pagos;
        }

        public Pago FindById(int? id)
        {
            Pago pago = null;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("select * from TipoInmobiliario where PagoId='" + id + "'", con);

                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            pago = new Pago();
                            pago.PagoId = Convert.ToInt32(dr[0]);
                            pago.NroTransaccion = dr["NroTrasaccion"].ToString();
                            pago.FechaTransaccion = Convert.ToDateTime(dr["FechaTransaccion"]);
                            pago.Contrato.cliente.NombreCliente = dr[3].ToString();

                        }
                    }
                }
            }
            catch (Exception ex) { throw; }

            return pago;
        }

        public bool insert(Pago t)
        {
            bool rpta = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["WALimaRooms"].ToString()))
                {
                    var query = new SqlCommand("insert into TipoInmobiliario values (@NroTransaccion," +
                        "                       @FechaTransaccion, @ContratoId)", con);
                    query.Parameters.AddWithValue("@NroTransaccion", t.NroTransaccion);
                    query.Parameters.AddWithValue("@FechaTransaccion", t.FechaTransaccion);
                    query.Parameters.AddWithValue("@ContratoId", t.Contrato.ContratoId);
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

        public bool Update(Pago t)
        {
            return pagoRepository.update(t);
        }
    }
}
