using Proyectommstore.Models;
using ProyectommStrore.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Proyectommstore.Dao.DaoImpl
{
    public class UsuarioDaoImpl : UsuarioDao
    {
       
        public Usuarios ObtenerUsuario(string indicador, string NombreUsuario)
        {

            Usuarios usuario = null;


            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_usuarios_operaciones", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@indicador", indicador);
                        cmd.Parameters.AddWithValue("@UsuarioID", (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@NombreUsuario", NombreUsuario);
                        cmd.Parameters.AddWithValue("@password", (object)DBNull.Value);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {



                            while (reader.Read())
                            {
                                usuario = new Usuarios
                                {
                                    UsuarioID = (int)reader["UsuarioID"],
                                    NombreUsuario = (string)reader["NombreUsuario"],
                                    password = (string)reader["password"]
                                };

                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                usuario = null;

            }

            return usuario;

        }

        
        public bool VerificarPassword(string passwordIngresado, string passwordAlmacenado)
        {
           

            return BCrypt.Net.BCrypt.Verify(passwordIngresado, passwordAlmacenado);
        }





        
        public int operacionesEscitura(string indicador, Usuarios objusu)
        {
            int procesar = -1;

            try
            {

                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_usuarios_crud", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Indicador", indicador);
                        cmd.Parameters.AddWithValue("@UsuarioID", objusu.UsuarioID);
                        cmd.Parameters.AddWithValue("@NombreUsuario", objusu.NombreUsuario);
                        cmd.Parameters.AddWithValue("@password", objusu.password);
                        cmd.Parameters.AddWithValue("@email", objusu.Email);
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
        

        //escribir el password en texto plano y que se guarde en Bcrypt en la base de datos
        public string HashPassword(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashedPassword;

        }

        public List<Usuarios> operacionesLectura(string indicador, Usuarios objusu)
        {
            List<Usuarios> lista = new List<Usuarios>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_usuarios_crud", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@indicador", indicador);
                        cmd.Parameters.AddWithValue("@UsuarioID", objusu.UsuarioID);
                        cmd.Parameters.AddWithValue("@NombreUsuario", objusu.NombreUsuario);
                        cmd.Parameters.AddWithValue("@password", objusu.password);
                        cmd.Parameters.AddWithValue("@email", objusu.Email);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            Usuarios usu;

                            while (reader.Read())
                            {
                                usu = new Usuarios();
                                usu.UsuarioID = reader.GetInt32(0);
                                usu.NombreUsuario = reader.GetString(1);
                                usu.password = reader.GetString(2);
                                usu.Email = reader.GetString(3);
                                lista.Add(usu);
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











     
 