using Proyectommstore.Dao;
using Proyectommstore.Dao.DaoImpl;
using Proyectommstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace Proyectommstore.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        UsuarioDao dao = new UsuarioDaoImpl();

        [HttpGet]
        [Route("getall")]
        public IHttpActionResult GetAll()
        {
            return Ok(dao.operacionesLectura("listar", new Usuarios()));
        }

       
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post( RegistroDTO registrardto)
        {

            // 1. Cifrar la contraseña
            string cifrado = dao.HashPassword(registrardto.Contraseña);  

            var nuevoUsuario = new Usuarios
            { 

              UsuarioID = 0, //la base de datos genera el id automaticamente
              NombreUsuario = registrardto.NombreUsuario,
              password = cifrado,
              Email = registrardto.Email,
            
            
            };

            // 3. Llamar al método del ServiceImpl para insertar el usuario
            int resultado = dao.operacionesEscitura("insertar", nuevoUsuario);

            if (resultado > 0)
            {
                return Ok("Usuario registrado correctamente.");
            }
            else
            {
                return BadRequest("Error al registrar el usuario.");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            return Ok(  dao.operacionesEscitura("eliminar", new Usuarios() { UsuarioID = id}));
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetId(int id)
        {
            var buscar = dao.operacionesLectura("buscar", new Usuarios() { UsuarioID = id}).FirstOrDefault();
            return Ok(buscar);
        }

    }
}
