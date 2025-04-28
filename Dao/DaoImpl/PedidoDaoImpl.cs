using Proyectommstore.Models;
using ProyectommStrore.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Proyectommstore.Dao.DaoImpl
{
    public class PedidoDaoImpl : PedidoDao

    {
        public List<Pedido> operacionesLectura(string indicador, Pedido objpe)
        {
            List<Pedido> lista = new List<Pedido>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_pedidos_crud2", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@indicador", indicador);
                        cmd.Parameters.AddWithValue("@PedidoID", objpe.PedidoID );
                        cmd.Parameters.AddWithValue("@ClienteID", objpe.ClienteID);
                        cmd.Parameters.AddWithValue("@FechaPedido", objpe.FechaPedido == default(DateTime) ? (object)DBNull.Value : objpe.FechaPedido);
                        cmd.Parameters.AddWithValue("@Estado", string.IsNullOrEmpty(objpe.Estado) ? (object)DBNull.Value : objpe.Estado);
                        cmd.Parameters.AddWithValue("@Total", objpe.Total == 0 ? (object)DBNull.Value : objpe.Total);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            

                            while (reader.Read())
                            {
                                Pedido pedi = new Pedido
                                {
                                    PedidoID = Convert.ToInt32(reader["PedidoID"]),
                                    ClienteID = Convert.ToInt32(reader["ClienteID"]),
                                    FechaPedido = Convert.ToDateTime(reader["FechaPedido"]),
                                    Estado = reader["Estado"].ToString(),
                                    Total = Convert.ToDecimal(reader["Total"])
                                };
                                lista.Add(pedi);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("OperacioneLectura -Eror" + ex.ToString());
            }

            return lista;
        }
    }
}