using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyectommstore.Models
{
    public class Usuarios
    {
        public int UsuarioID { get; set; }
        public string NombreUsuario { get; set; }
        public string password { get; set; }
        public string Email { get; set; }

      

        public Usuarios()
        {
            this.UsuarioID = 0;
            this.NombreUsuario = "";
            this.password = "";
            this.Email = "";
        }

        public Usuarios(int usuarioID, string nombreUsuario, string password, string email)
        {
            UsuarioID = usuarioID;
            NombreUsuario = nombreUsuario;
            this.password = password;
            Email = email;
        }
    }
}