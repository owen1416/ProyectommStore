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
    public class ProductoDaoImpl : ProductoDao
    {
        public int operacionesEscritura(string indicador, Productos objpro)
        {
            int procesar = -1;

            try
            {

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_productos_crud", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@indicador", indicador);
                        cmd.Parameters.AddWithValue("@ProductoID", objpro.ProductoID);
                        cmd.Parameters.AddWithValue("@nombre", objpro.Nombre);
                        cmd.Parameters.AddWithValue("@marca", objpro.Marca);
                        cmd.Parameters.AddWithValue("@modelo", objpro.Modelo);
                        cmd.Parameters.AddWithValue("@descripcion", objpro.Descripcion);
                        cmd.Parameters.AddWithValue("@precio", objpro.Precio);
                        cmd.Parameters.AddWithValue("@stock", objpro.Stock);
                        cmd.Parameters.AddWithValue("@categoria", objpro.Categoria);
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

        public List<Productos> operacionesLectura(string indicador, Productos objpro)
        {
            List<Productos> lista = new List<Productos>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_productos_crud", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@indicador", indicador);
                        cmd.Parameters.AddWithValue("@ProductoID", objpro.ProductoID);
                        cmd.Parameters.AddWithValue("@nombre", objpro.Nombre);
                        cmd.Parameters.AddWithValue("@marca", objpro.Marca);
                        cmd.Parameters.AddWithValue("@modelo", objpro.Modelo);
                        cmd.Parameters.AddWithValue("@descripcion", objpro.Descripcion);
                        cmd.Parameters.AddWithValue("@precio", objpro.Precio);
                        cmd.Parameters.AddWithValue("@stock", objpro.Stock);
                        cmd.Parameters.AddWithValue("@categoria", objpro.Categoria);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Productos pro;

                            while (reader.Read())
                            {
                                pro = new Productos();
                                pro.ProductoID = reader.GetInt32(0);
                                pro.Nombre = reader.GetString(1);
                                pro.Marca = reader.GetString(2);
                                pro.Modelo = reader.GetString(3);
                                pro.Descripcion = reader.GetString(4);
                                pro.Precio = reader.GetDecimal(5);
                                pro.Stock = reader.GetInt32(6);
                                pro.Categoria = reader.GetString(7);
                                lista.Add(pro);
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
