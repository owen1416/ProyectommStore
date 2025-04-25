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
    public class UsuarioDaoImpl : UsuarioDao
    {
        public Usuarios ObtenerUsuario(string indicador, string NombreUsuario)
        {

            Usuarios usuario = null;
          

            try
            {
                using(SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString))
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

                            

                            while(reader.Read())
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
            // Agrega estas líneas para depuración
          
            return BCrypt.Net.BCrypt.Verify(passwordIngresado, passwordAlmacenado);
        }
    }
}