using Proyectommstore.Dao;
using Proyectommstore.Dao.DaoImpl;
using Proyectommstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;
using System.Web.Routing;
using System.Web.UI.WebControls;

namespace Proyectommstore.Controllers
{

    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
      
        UsuarioDao dao = new UsuarioDaoImpl();

        [HttpPost]
        [Route("login")]
        public IHttpActionResult login([FromBody] LoginDTO login)
        {
            if (!ModelState.IsValid || login == null || string.IsNullOrEmpty(login.NombreUsuario)||string.IsNullOrEmpty(login.password))
            { 
              return BadRequest("Credenciales invalidas");
            }

            Usuarios usuario = dao.ObtenerUsuario("obtenerusu", login.NombreUsuario);

            if (usuario == null)
            {       
              return Unauthorized(); 
            }

            if (dao.VerificarPassword(login.password, usuario.password))
            {
                return Ok(new { Mensaje = "Inicio de sesion exitoso", UsuarioID = usuario.UsuarioID, nombreUsuario = usuario.NombreUsuario });
            }
            else 
            {
                return Unauthorized();
            }

           
        }

    }
}
