using Proyectommstore.Models;
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
        public int OperacionesEscrituraPedido(string indicador, Pedido objPedido)
        {
            int procesar = -1;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_pedidos_crud", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@indicador", indicador);
                        cmd.Parameters.AddWithValue("@PedidoID", objPedido.PedidoID);
                        cmd.Parameters.AddWithValue("@ClienteID", objPedido.ClienteID);
                        cmd.Parameters.AddWithValue("@FechaPedido", objPedido.FechaPedido);
                        cmd.Parameters.AddWithValue("@Estado", objPedido.Estado);
                        cmd.Parameters.AddWithValue("@Total", objPedido.Total);

                        if (indicador == "insertar")
                        {
                            SqlParameter outputIdParam = new SqlParameter("@PedidoIDOutput", System.Data.SqlDbType.Int);
                            outputIdParam.Direction = System.Data.ParameterDirection.Output;
                            cmd.Parameters.Add(outputIdParam);

                            procesar = cmd.ExecuteNonQuery();

                            if (outputIdParam.Value != DBNull.Value)
                            {
                                objPedido.PedidoID = Convert.ToInt32(outputIdParam.Value);
                            }
                        }
                        else
                        {
                            procesar = cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("OperacionesEscrituraPedido - Error:" + ex.ToString());
            }
            return procesar;
        }



        public Pedido OperacionesLecturaPedido(string indicador, Pedido objPedido)
        {
            Pedido pedido = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_pedidos_crud", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@indicador", indicador);
                        cmd.Parameters.AddWithValue("@PedidoID", objPedido.PedidoID);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                pedido = new Pedido
                                {
                                    PedidoID = reader.GetInt32(0),
                                    ClienteID = reader.GetInt32(1),
                                    FechaPedido = reader.GetDateTime(2),
                                    Estado = reader.GetString(3),
                                    Total = reader.GetDecimal(4)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("OperacionesLecturaPedido - Error:" + ex.ToString());
            }
            return pedido;
        }
        public int OperacionesEscrituraDetallePedido(string indicador, DetallePedido objDetallePedido)
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
                        cmd.Parameters.AddWithValue("@DetallePedidoID", objDetallePedido.DetallePedidoID);
                        cmd.Parameters.AddWithValue("@PedidoID", objDetallePedido.PedidoID);
                        cmd.Parameters.AddWithValue("@ProductoID", objDetallePedido.ProductoID);
                        cmd.Parameters.AddWithValue("@Cantidad", objDetallePedido.Cantidad);
                        cmd.Parameters.AddWithValue("@PrecioUnitario", objDetallePedido.PrecioUnitario);
                        cmd.Parameters.AddWithValue("@Subtotal", objDetallePedido.Subtotal);
                        procesar = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("OperacionesEscrituraDetallePedido - Error: " + ex.ToString());
            }
            return procesar;
        }
    }

       

    }
