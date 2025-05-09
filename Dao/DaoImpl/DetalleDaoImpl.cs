using Proyectommstore.Models;
using ProyectommStrore.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting;
using System.Web;

namespace Proyectommstore.Dao.DaoImpl
{
    public class DetalleDaoImpl : DetalleDao
    {
        public int operacionesEscritura(string indicador, DetallePedido objdetalle)
        {
            int procesar = -1;

            try
            {

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_detalle_pedido_crud", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@indicador", indicador);
                        cmd.Parameters.AddWithValue("@DetallePedidoID", objdetalle.DetallePedidoID);
                        cmd.Parameters.AddWithValue("@PedidoID", objdetalle.PedidoID);
                        cmd.Parameters.AddWithValue("@ProductoID", objdetalle.ProductoID);
                        cmd.Parameters.AddWithValue("@Cantidad", objdetalle.Cantidad);
                        cmd.Parameters.AddWithValue("@PrecioUnitario", objdetalle.PrecioUnitario);
                        cmd.Parameters.AddWithValue("@Subtotal", objdetalle.Subtotal);
                        procesar = cmd.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine("OperacionesEscritura -Error");
            }

            return procesar;
        }

        public List<DetallePedido> operacionesLectura(string indicador, DetallePedido objdetalle)
        {
            List<DetallePedido> lista = new List<DetallePedido>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_detalle_pedido_crud", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@indicador", indicador);
                        cmd.Parameters.AddWithValue("@DetallePedidoID", objdetalle.DetallePedidoID);
                        cmd.Parameters.AddWithValue("@PedidoID", objdetalle.PedidoID);
                        cmd.Parameters.AddWithValue("@ProductoID", objdetalle.ProductoID);
                        cmd.Parameters.AddWithValue("@Cantidad", objdetalle.Cantidad);
                        cmd.Parameters.AddWithValue("@PrecioUnitario", objdetalle.PrecioUnitario);
                        cmd.Parameters.AddWithValue("@Subtotal", objdetalle.Subtotal);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DetallePedido ped;

                            while (reader.Read())
                            {
                                ped = new DetallePedido();
                                ped.DetallePedidoID = reader.GetInt32(0);
                                ped.PedidoID = reader.GetInt32(1);
                                ped.ProductoID = reader.GetInt32(2);
                                ped.Cantidad = reader.GetInt32(3);
                                ped.PrecioUnitario = reader.GetDecimal(4);
                                ped.Subtotal = reader.GetDecimal(5);
                                lista.Add(ped);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("OperacionesLectura -Eror" + ex.ToString());
            }

            return lista;
        }

    }
}