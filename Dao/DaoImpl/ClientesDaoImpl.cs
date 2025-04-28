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
    public class ClientesDaoImpl : ClientesDao
    {
        public int operacionesEscritura(string indicador, Clientes objcli)
        {
            int procesar = -1;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_clientes_crud", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@indicador", indicador);
                        cmd.Parameters.AddWithValue("@clienteID", objcli.ClienteID);
                        cmd.Parameters.AddWithValue("@nombre", objcli.Nombre);
                        cmd.Parameters.AddWithValue("@apellido", objcli.Apellido);
                        cmd.Parameters.AddWithValue("@email", objcli.Email);
                        cmd.Parameters.AddWithValue("@telefono", objcli.Telefono);
                        cmd.Parameters.AddWithValue("@nrdocumento", objcli.NrDocumento);
                        cmd.Parameters.AddWithValue("@documento", objcli.Documento);
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

        public List<Clientes> operacionesLectura(string indicador, Clientes objcli)
        {
            List<Clientes> lista = new List<Clientes>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_clientes_crud", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@indicador", indicador);
                        cmd.Parameters.AddWithValue("@clienteID", objcli.ClienteID);
                        cmd.Parameters.AddWithValue("@nombre", objcli.Nombre);
                        cmd.Parameters.AddWithValue("@apellido", objcli.Apellido);
                        cmd.Parameters.AddWithValue("@email", objcli.Email);
                        cmd.Parameters.AddWithValue("@telefono", objcli.Telefono);
                        cmd.Parameters.AddWithValue("@nrdocumento", objcli.NrDocumento);
                        cmd.Parameters.AddWithValue("@documento", objcli.Documento);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Clientes cli;

                            while (reader.Read())
                            {
                                cli = new Clientes();
                                cli.ClienteID = reader.GetInt32(0);
                                cli.Nombre = reader.GetString(1);
                                cli.Apellido = reader.GetString(2);
                                cli.Email = reader.GetString(3);
                                cli.Telefono = reader.GetString(4);
                                cli.NrDocumento = reader.GetInt32(5);
                                cli.Documento = reader.GetString(6);
                                lista.Add(cli);
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